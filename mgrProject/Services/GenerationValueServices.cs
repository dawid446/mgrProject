using AutoMapper;
using Bogus;
using Domain.Entity;
using Domain.Entity.DTO;
using mgrProject.Interfaces;
using mgrProject.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mgrProject.Services
{

    public class GenerationValueServices : IGenerationValueServices
    {
        private readonly IMapper _mapper;

        public GenerationValueServices(IMapper mapper)
        {
            _mapper = mapper;
        }
        public void generationMain(int count, string table)
        {
            shopContext context = new shopContext();
            switch (table)
            {
                case "product" :
                    var generators = generatorCategory(count);
                    context.Add(generatorProduct(count, generators.ToList()));
                    break;
                case "category" :
                    generatorCategory(count);
                    break;
                case "user":
                    generatorUser(count);
                    break;
                case "order_status":
                    generatorOrderStatus(count);
                    break;
                case "shipment_adress":
                    var user = generatorUser(count);
                    generatorShipmentAdress(count, user.ToList());
                    break;
                case "payment_detail":
                    generatorPaymentDetail(count);
                    break;
                case "shipment_detail":
                    generatorShipmentDetail(count);
                    break;
                case "order":
                    var orderStatus = generatorOrderStatus(count).ToList();
                    var paymentDetail = generatorPaymentDetail(count).ToList();
                    var users = generatorUser(count).ToList();
                    var shipA = generatorShipmentAdress(count, users).ToList();
                    var shipD = generatorShipmentDetail(count).ToList();
                    generatorOrder(count,orderStatus,paymentDetail,shipA,shipD,users);
                    break;
                case "cart":
                    var user1 = generatorUser(count);
                    context.Add(generatorCart(count, user1.ToList()));
                    break;
                case "order_product":
                    var orderStatus1 = generatorOrderStatus(count).ToList();
                    var paymentDetail1 = generatorPaymentDetail(count).ToList();
                    var users1 = generatorUser(count).ToList();
                    var shipA1 = generatorShipmentAdress(count, users1).ToList();
                    var shipD1 = generatorShipmentDetail(count).ToList();
                    var order = generatorOrder(count, orderStatus1, paymentDetail1, shipA1, shipD1, users1).ToList();
                    var generators1 = generatorCategory(count).ToList();
                    var product = generatorProduct(count, generators1).ToList();
                    generatorOrderProduct(count, order, product);
                    break;
                case "shopping_cart":
                    var generators2 = generatorCategory(count).ToList();
                    var product1 = generatorProduct(count, generators2).ToList();
                    var user2 = generatorUser(count).ToList();
                    var cart = generatorCart(count, user2).ToList();
                    generatorShoppingCart(count, product1, cart);
                    break;
                default:
                    break;
            }
            context.SaveChanges();
        }
        private IEnumerable<Product> generatorProduct(int count, List<Category> listCategory)
        {
            var productId = 1;
            var product = new Faker<ProductDTO>()
              .RuleFor(x => x.IdProduct, f => productId++)
              .RuleFor(x => x.Title, f => f.Commerce.Product())
              .RuleFor(x => x.ShortDescription, f => f.Commerce.ProductDescription())
              .RuleFor(x => x.Price, f => (float)f.Finance.Amount(0, 1000, 2))
              .RuleFor(x => x.Discount, f => f.Random.Float())
              .RuleFor(x => x.Quantity, f => f.Random.Number(1, 10))
              .RuleFor(x => x.CreateDate, f => f.Date.Recent(0))
              .RuleFor(x => x.PublishedDate, f => f.Date.Recent(0))
              .RuleFor(x => x.ShortDescription, f => f.Commerce.ProductDescription())
              .RuleFor(x => x.ContentText, f => f.Commerce.ProductDescription())
              .RuleFor(x => x.IdCategoryFk, f => f.PickRandom(listCategory).IdCategory);

            var productGenerator = product.Generate(count);
            var resultPro = _mapper.Map<IEnumerable<Product>>(productGenerator);
            return resultPro;

        }
        private IEnumerable<User> generatorUser(int count)
        {
            var userId = 1;
            var user = new Faker<UserDTO>()
                .StrictMode(true)
                .RuleFor(x => x.IdUser, f => userId++)
                .RuleFor(x => x.EmailConfirmed, f => f.Random.Bool())
                .RuleFor(x => x.Email, f => f.Person.Email)
                .RuleFor(x => x.Lockout, f => f.Random.Bool())
                .RuleFor(x => x.LockoutDate, f => f.Date.Recent(0))
                .RuleFor(x => x.PasswordHash, f => f.Random.Hash())
                .RuleFor(x => x.PhoneNumer, f => f.Person.Phone)
                .RuleFor(x => x.PhoneNumerConfirmed, f => f.Random.Bool())
                .RuleFor(x => x.TwoFactoryEnabled, f => f.Random.Bool())
                .RuleFor(x => x.UserName, f => f.Person.UserName);

            var userGenerato = user.Generate(count);
            var result = _mapper.Map<IEnumerable<User>>(userGenerato);
            return result;
        }
        private IEnumerable<Category> generatorCategory(int count)
        {
            var categoryId = 1;
            var category = new Faker<CategoryDTO>()
               .StrictMode(true)
               .RuleFor(x => x.IdCategory, f => categoryId++)
               .RuleFor(x => x.CategoryName, f => f.Commerce.ProductMaterial())
               .RuleFor(x => x.Description, f => f.Commerce.ProductDescription());

            var categoryGenerato = category.Generate(10000);
            var resultCat = _mapper.Map<IEnumerable<Category>>(categoryGenerato);

            return resultCat;
        }
        private IEnumerable<ShipmentAdress> generatorShipmentAdress(int count, List<User> userGenerator)
        {
            var shipmentId = 1;
            var shipment = new Faker<ShipmentAdressDTO>()
              .StrictMode(true)
              .RuleFor(x => x.IdShipmentAdress, f => shipmentId++)
              .RuleFor(x => x.Name, f => f.Person.FirstName)
              .RuleFor(x => x.Surname, f => f.Person.LastName)
              .RuleFor(x => x.Company, f => f.Company.CompanyName())
              .RuleFor(x => x.Adress, f => f.Address.StreetAddress())
              .RuleFor(x => x.City, f => f.Address.City())
              .RuleFor(x => x.CityCode, f => f.Address.ZipCode())
              .RuleFor(x => x.Country, f => f.Address.Country())
              .RuleFor(x => x.Mobile, f => f.Person.Phone)
              .RuleFor(x => x.UserIduser, f => f.PickRandom(userGenerator).IdUser);

            var shipmentGenerator = shipment.Generate(count);
            var resultsh = _mapper.Map<IEnumerable<ShipmentAdress>>(shipmentGenerator);

            return resultsh;
        }
        private IEnumerable<OrderStatus> generatorOrderStatus(int count)
        {
            var oderStatus = new List<OrderStatusDTO>()
            {
                new OrderStatusDTO { IdOrderStatus = 1,  NameStatus = "Pending Payment"},
                new OrderStatusDTO { IdOrderStatus = 2,  NameStatus = "Shipped"},
                new OrderStatusDTO { IdOrderStatus = 3,  NameStatus = "Processing"},
                new OrderStatusDTO { IdOrderStatus = 4,  NameStatus = "On Hold"},
                new OrderStatusDTO { IdOrderStatus = 5,  NameStatus = "Completed"},
                new OrderStatusDTO { IdOrderStatus = 6,  NameStatus = "Cancelled"},
                new OrderStatusDTO { IdOrderStatus = 7,  NameStatus = "Refunded"},
                new OrderStatusDTO { IdOrderStatus = 8,  NameStatus = "Failed"}
            };
            var resultOrderStatus = _mapper.Map<IEnumerable<OrderStatus>>(count);
            return resultOrderStatus;
        }
        private IEnumerable<PaymentDetail> generatorPaymentDetail(int count)
        {
            var paymentDetailId = 1;
            var paymentDetail = new Faker<PaymentDetailDTO>()
              .StrictMode(true)
              .RuleFor(x => x.IdPaymentDetails, f => paymentDetailId++)
              .RuleFor(x => x.Provider, f => f.Company.CompanyName())
              .RuleFor(x => x.IdProvider, f => string.Join("", f.Random.Digits(9, 0, 9)))
              .RuleFor(x => x.StatusProvider, f => f.PickRandom<StatusProvider>().ToString())
              .RuleFor(x => x.CreateDate, f => f.Date.Recent(0));

            var paymentGenerator = paymentDetail.Generate(count);
            var resultpayment = _mapper.Map<IEnumerable<PaymentDetail>>(paymentGenerator);

            return resultpayment;
        }
        private IEnumerable<ShipmentDetail> generatorShipmentDetail(int count)
        {
            var shipmentDetailsId = 1;
            var shipmentDetails = new Faker<ShipmentDetailDTO>()
              .StrictMode(true)
              .RuleFor(x => x.IdShipmentDetails, f => shipmentDetailsId++)
              .RuleFor(x => x.ProviderName, f => f.Company.CompanyName())
              .RuleFor(x => x.Status, f => f.PickRandom<StatusShipping>().ToString())
              .RuleFor(x => x.TrackingNumber, f => string.Join("", f.Random.Digits(9, 0, 9)))
              .RuleFor(x => x.BarcodeProvider, f => string.Join("", f.Random.Digits(9, 0, 9)))
              .RuleFor(x => x.StatusProvider, f => f.PickRandom<StatusProvider>().ToString())
              .RuleFor(x => x.ShipmentDate, f => f.Date.Between(new DateTime(1999, 01, 01), DateTime.Now));
            var shipmenDetailtGenerator = shipmentDetails.Generate(count);

            var resultShipmentDetail = _mapper.Map<IEnumerable<ShipmentDetail>>(shipmenDetailtGenerator);

            return resultShipmentDetail;
        }
        private IEnumerable<Order> generatorOrder(int count, List<OrderStatus> orderStatus, List<PaymentDetail> payment, List<ShipmentAdress> shipmentAddress, List<ShipmentDetail> shipmentDetails, List<User> user)
        {
            var orderId = 1;
            var order = new Faker<OrderDTO>()
              .StrictMode(true)
              .RuleFor(x => x.IdOrder, f => orderId++)
              .RuleFor(x => x.TotalPrice, f => (float)f.Finance.Amount(0, 1000, 2))
              .RuleFor(x => x.ShippingCost, f => (float)f.Finance.Amount(0, 20, 2))
              .RuleFor(x => x.OrderDate, f => f.Date.Between(new DateTime(1999, 01, 01), DateTime.Now))
              .RuleFor(x => x.Comment, f => f.Random.Words(10))
              .RuleFor(x => x.Token, f => f.Random.Hash(6))
              .RuleFor(x => x.Canceled, f => f.Random.Bool())
              .RuleFor(x => x.CanceledDate, f => f.Date.Recent(0))
              .RuleFor(x => x.CanceledComment, f => f.Random.Words(5))
              .RuleFor(x => x.IdOrderStatusFk, f => f.PickRandom(orderStatus).IdOrderStatus)
              .RuleFor(x => x.IdPaymentDetailsFk, f => f.PickRandom(payment).IdPaymentDetails)
              .RuleFor(x => x.IdShipmentAdressFk, f => f.PickRandom(shipmentAddress).IdShipmentAdress)
              .RuleFor(x => x.IdShipmentDetailsFk, f => f.PickRandom(shipmentDetails).IdShipmentDetails)
              .RuleFor(x => x.IdUserFk, f => f.PickRandom(user).IdUser);

            var orderGenerator = order.Generate(count);
            var resultorder = _mapper.Map<IEnumerable<Order>>(orderGenerator);

            return resultorder;
        }
        private IEnumerable<Cart> generatorCart(int count, List<User> userGenerator)
        {
            var cartId = 1;
            var cart = new Faker<CartDTO>()
              .StrictMode(true)
              .RuleFor(x => x.IdCart, f => cartId++)
              .RuleFor(x => x.Active, f => f.Random.Bool())
              .RuleFor(x => x.SessionId, f => string.Join("", f.Random.Digits(9, 0, 9)))
              .RuleFor(x => x.Token, f => string.Join("", f.Random.Digits(9, 0, 9)))
              .RuleFor(x => x.IdUserFk, f => f.PickRandom(userGenerator).IdUser);

            var cartGenerator = cart.Generate(count);
            var resultCart = _mapper.Map<IEnumerable<Cart>>(cartGenerator);

            return resultCart;

        }
        private IEnumerable<OrderProduct> generatorOrderProduct(int count, List<Order> order, List<Product> product)
        {
            var orderProductId = 1;
            var orderProduct = new Faker<OrderProductDTO>()
              .StrictMode(true)
              .RuleFor(x => x.IdOrderProduct, f => orderProductId++)
              .RuleFor(x => x.QuantityOrder, f => f.Random.Number(1, 10))
              .RuleFor(x => x.PriceEach, f => (float)f.Finance.Amount(0, 20, 2))
              .RuleFor(x => x.IdOrderFk, f => f.PickRandom(order).IdOrder)
              .RuleFor(x => x.IdProductFk, f => f.PickRandom(product).IdProduct);
            var orderproductGenerator = orderProduct.Generate(count);

            var resultOrderProduct = _mapper.Map<IEnumerable<OrderProduct>>(orderproductGenerator);
            return resultOrderProduct;
        }
        private IEnumerable<ShoppingCart> generatorShoppingCart(int count, List<Product> product, List<Cart> cart)
        {
            var shoppingCardId = 1;
            var shoppingCart = new Faker<ShoppingCartDTO>()
              .StrictMode(true)
              .RuleFor(x => x.IdShoppingCart, f => shoppingCardId++)
              .RuleFor(x => x.QuantityCart, f => f.Random.Number(1, 10))
              .RuleFor(x => x.UpdatedDate, f => f.Date.Recent(0))
              .RuleFor(x => x.PriceEach, f => (float)f.Finance.Amount(0, 20, 2))
              .RuleFor(x => x.CreateDate, f => f.Date.Recent(0))
              .RuleFor(x => x.IdProductFk, f => f.PickRandom(product).IdProduct)
              .RuleFor(x => x.IdCartFk, f => f.PickRandom(cart).IdCart);
            var shoppingCartGenerator = shoppingCart.Generate(count);

            var resultshoppingCart = _mapper.Map<IEnumerable<ShoppingCart>>(shoppingCartGenerator);

            return resultshoppingCart;

        }


    }
}
