using log4net;
using ShopConsoleApp.Enums;
using ShopConsoleApp.Models;
using ShopConsoleApp.Models.ProductModels;
using ShopConsoleApp.Services;
using System.Reflection;

namespace ShopConsoleApp;

public class ShopController
{
    private readonly ILog _log = LogManager.GetLogger(typeof(ShopController));

    private readonly UserService _userService = UserService.Instance;
    private readonly CartService _cartService = CartService.Instance;
    private readonly ProductService _productService = ProductService.Instance;
    private readonly ProductStockService _productStockService = ProductStockService.Instance;

    public ShopController()
    {
        BookProductModel book1 = new("Harry Potter and Philosopher's Stone", 325)
        {
            Description = "Harry Potter has never even heard of Hogwarts when the letters start dropping on the doormat at number four, Privet Drive. Addressed in green ink on yellowish parchment with a purple seal, they are swiftly confiscated by his grisly aunt and uncle. Then, on Harry's eleventh birthday, a great beetle-eyed giant of a man called Rubeus Hagrid bursts in with some astonishing news: Harry Potter is a wizard, and he has a place at Hogwarts School of Witchcraft and Wizardry. An incredible adventure is about to begin!\r\n\r\nThese new editions of the classic and internationally bestselling, multi-award-winning series feature instantly pick-up-able new jackets by Jonny Duddle, with huge child appeal, to bring Harry Potter to the next generation of readers. It's time to PASS THE MAGIC ON.",
            Author = "J.K. Rowling",
            Language = "English",
            Publisher = "Bloomsbury"
        };
        BookProductModel book2 = new("Harry Potter and Order of the Phoenix", 450)
        {
            Description = "Harry Potter is about to start his fifth year at Hogwarts School of Witchcraft and Wizardry. Unlike most schoolboys, Harry never enjoys his summer holidays, but this summer is even worse than usual. The Dursleys, of course, are making his life a misery, but even his best friends, Ron and Hermione, seem to be neglecting him.\nHarry has had enough. He is beginning to think he must do something, anything, to change his situation, when the summer holidays come to an end in a very dramatic fashion. What Harry is about to discover in his new year at Hogwarts will turn his world upside down...",
            Author = "J.K. Rowling",
            Language = "English",
            Publisher = "Bloomsbury"
        };
        ShirtProductModel shirt1 = new("Classic Fit Striped Poplin Fun Shirt", 7920)
        {
            Description = "Decades ago, tailors would learn their craft by sewing together shirts made from fabric remnants. Over time, a staple of playful preppy style evolved from the practice—the fun shirt. This unisex version combines four striped patterns into a single statement-making shirt, adorned with a PRL monogram.",
            Brand = "Polo Ralph Lauren",
            Size = ClothingSizes.M,
            Material = "100% cotton"
        };
        ShirtProductModel shirt2 = new("Garment-Dyed Oxford Shirt - All Fits", 6520)
        {
            Description = "Garment-dyed and washed, this cotton shirt offers a broken-in look and feel from day one.",
            Brand = "Polo Ralph Lauren",
            Size = ClothingSizes.XL,
            Material = "100% cotton"
        };
        TableProductModel table1 = new("Cala Solid Acacia Wood Parquet Style Industrial Dining Table", 25999)
        {
            Description = "Incorporating this stunning table into your modern industrial-style home is sure to make a resounding statement. The tabletop, hewn from exquisite Acacia wood, rests gracefully on a sleek, black powder-coated modern base. The Cala table is not just a visual delight; it's also a testament to exceptional build quality and meticulous finishing.",
            Brand = "COKU Home",
            Type = "Dining table",
            Dimensions = (1.1, 1.1, 0.76),
            Material = "Acacia Wood, Steel"
        };
        TableProductModel table2 = new("Leo Parquet Style Solid Mango Wood Industrial Dining Table", 27699)
        {
            Description = "The Leo luxury solid mango wood dining table is a stunning interpretation of the modern industrial style. This beautiful, solid and well built dining table features an expertly crafted parquet style tabletop. Check out our sensational industrial distressed finish that features a unique 3D texture. Because of the nature of solid wood, every table will be unique and 1 of 1. This is no ordinary industrial table. Exclusively designed and produced by us, so you won't find this table anywhere else.",
            Brand = "COKU Home",
            Type = "Dining table",
            Dimensions = (1.8, 0.9, 0.77),
            Material = "Mango Wood, Steel"
        };

        _productService.CreateProduct(book1);
        _productService.CreateProduct(book2);
        _productService.CreateProduct(shirt1);
        _productService.CreateProduct(shirt2);
        _productService.CreateProduct(table1);
        _productService.CreateProduct(table2);

        var cartItemBook1 = new ProductStock(book1.Id, 10);
        var cartItemBook2 = new ProductStock(book2.Id, 7);
        var cartItemShirt1 = new ProductStock(shirt1.Id, 3);
        var cartItemShirt2 = new ProductStock(shirt2.Id, 5);
        var cartItemTable1 = new ProductStock(table1.Id, 4);
        var cartItemTable2 = new ProductStock(table2.Id, 3);

        _productStockService.CreateProductStock(cartItemBook1);
        _productStockService.CreateProductStock(cartItemBook2);
        _productStockService.CreateProductStock(cartItemShirt1);
        _productStockService.CreateProductStock(cartItemShirt2);
        _productStockService.CreateProductStock(cartItemTable1);
        _productStockService.CreateProductStock(cartItemTable2);
    }

    public void Register(string email, string password)
    {
        try
        {
            Console.WriteLine("[REGISTRATION]\n");

            //Console.Write("Enter your email: ");
            //var email = Console.ReadLine();
    
            //Console.Write("Create a password: ");
            //var password = Console.ReadLine();

            _ = _userService.Register(email, password);

            Console.WriteLine("The registration was successful!");
        }
        catch (ApplicationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public void Login(string email, string password)
    {
        try
        {
            Console.WriteLine("[LOGIN]\n");

            //Console.Write("Enter your email: ");
            //var email = Console.ReadLine();

            //Console.Write("Create a password: ");
            //var password = Console.ReadLine();

            _ = _userService.Login(email, password);
        }
        catch (ApplicationException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public void AddProductToCart(string email, ProductModel product, int count)
    {
        var user = _userService.GetUserByEmail(email);
        var cart = _cartService.GetCartByUserId(user.Id);
        var productStocks = _productStockService.GetAllProductStocks();


        foreach (var productStock in productStocks.Values)
        {
            if (productStock.ProductId == product.Id && productStock.Count < count)
            {
                Console.WriteLine("F");
                return;
            }
        }

        foreach (var cartItem in cart.CartItems)
        {
            if (cartItem.ProductId == product.Id)
            {
                _cartService.AddQuantityToProduct(cart, product, count);
                return;
            }
        }

        _cartService.AddProduct(cart, product, count);
    }


    //public Dictionary<Guid, ProductStock> GetAssortmentProducts() => _productStockService.GetAllProductStocks();
    public Dictionary<Guid, ProductModel> GetAssortmentProducts() => _productService.GetAllProduct();

    public void ShowCartUser(string email)
    {
        var user = _userService.GetUserByEmail(email);
        var cart = _cartService.GetCartByUserId(user.Id);

        // todo ShowCartUser()
        //var productId = cart.CartItems[0].ProductId;
        //var product = _productService.GetProductById(productId);
        //Console.WriteLine(product.Title);
    }

    public void FirstElement(string email)
    {
        var user = _userService.GetUserByEmail(email);
        var cart = _cartService.GetCartByUserId(user.Id);

        _productService
    }
}