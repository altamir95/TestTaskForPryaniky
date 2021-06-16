using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestTaskForPryaniky.Models;
using TestTaskForPryaniky.Enums;
using TestTaskForPryaniky.ViewModels;

namespace TestTaskForPryaniky.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        int CurrentUserId = 1;

        [HttpGet]
        public IActionResult GetListProductsInCart()
        {
            User currentUser;
            currentUser = StaticDB.Users.FirstOrDefault(u => u.Id == CurrentUserId);
            if (currentUser == null) ModelState.AddModelError("errors", HttpRequestValues.current_user_unexist_in_database.ToString());

            if (!ModelState.IsValid) return BadRequest(ModelState);

            Cart currentUserCart;
            currentUserCart = StaticDB.Carts.FirstOrDefault(u => u.Id == currentUser.Id);
            if (currentUserCart == null)
            {
                int newCartId = StaticDB.Carts.Count + 1;
                StaticDB.Carts.Add(new Cart { Id = newCartId,UserId= currentUser.Id });
                StaticDB.Users.ForEach(u => { if (u.Id == currentUser.Id) { u.CartId = newCartId;  } });
            }

            IEnumerable<CartProductsModel> productsInUserCart;
            productsInUserCart = StaticDB.CartProducts
                .Where(w => w.CartId == currentUser.CartId)
                .GroupBy(i => i.ProductId)
                .Select(c => new CartProductsModel() { ProductId = c.Key, Name = StaticDB.Products.FirstOrDefault(p => p.Id == c.Key).Name, Count = c.Count() });

            return new ObjectResult(productsInUserCart);
        }

        [HttpPut]
        public IActionResult PutInCart(PutInCartViewModel viewModel)
        {
            if (viewModel==null) ModelState.AddModelError("errors", HttpRequestValues.patametr_is_null.ToString());
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (viewModel.ProductId < 1) ModelState.AddModelError("errors", HttpRequestValues.patametr_is_less_one.ToString());
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Product product;
            product = StaticDB.Products.FirstOrDefault(p => p.Id == viewModel.ProductId);
            if (product == null) ModelState.AddModelError("errors", HttpRequestValues.product_unexist.ToString());
            if (!ModelState.IsValid) return BadRequest(ModelState);

            User currentUser; 
            currentUser = StaticDB.Users.FirstOrDefault(u => u.Id == CurrentUserId);
            if (currentUser == null) ModelState.AddModelError("errors", HttpRequestValues.current_user_unexist_in_database.ToString());
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Cart currentUserCart; 
            currentUserCart = StaticDB.Carts.FirstOrDefault(u => u.Id == currentUser.Id);
            if (currentUserCart == null)
            {
                int newCartId = StaticDB.Carts.Count + 1;
                StaticDB.Carts.Add(new Cart { Id = newCartId, UserId = currentUser.Id });
                StaticDB.Users.ForEach(u => { if (u.Id == currentUser.Id) { u.CartId = newCartId;   } }); 
            }

            StaticDB.CartProducts.Add(new CartProduct() { CartId = currentUser.CartId, ProductId = viewModel.ProductId, Id = StaticDB.CartProducts.Count + 1 });

            return Ok(HttpRequestValues.successfully.ToString());
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteFromCart(int productId)
        {
            if (productId < 1) ModelState.AddModelError("errors", HttpRequestValues.patametr_is_less_one.ToString());
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Product product;
            product = StaticDB.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null) ModelState.AddModelError("errors", HttpRequestValues.product_unexist.ToString());
            if (!ModelState.IsValid) return BadRequest(ModelState);

            User currentUser;
            currentUser = StaticDB.Users.FirstOrDefault(u => u.Id == CurrentUserId);
            if (currentUser == null) ModelState.AddModelError("errors", HttpRequestValues.current_user_unexist_in_database.ToString());
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Cart currentUserCart;
            currentUserCart = StaticDB.Carts.FirstOrDefault(u => u.Id == currentUser.Id);
            if (currentUserCart == null)
            {
                int newCartId = StaticDB.Carts.Count + 1;
                StaticDB.Carts.Add(new Cart { Id = newCartId, UserId = currentUser.Id });
                StaticDB.Users.ForEach(u => { if (u.Id == currentUser.Id) { u.CartId = newCartId; } });
            }

            CartProduct cartProduct;
            cartProduct = StaticDB.CartProducts.FirstOrDefault(p => p.ProductId == productId && p.CartId == currentUserCart.Id);
            if (cartProduct == null) return Ok(HttpRequestValues.product_was_out.ToString());

            StaticDB.CartProducts.Remove(cartProduct);

            return Ok(HttpRequestValues.successfully.ToString());
        }
    }
}
