using log4net;
using ShopConsoleApp.Enums;
using ShopConsoleApp.Models;
using ShopConsoleApp.Models.ProductModels;
using ShopConsoleApp.Services;

namespace ShopConsoleApp;

public class ShopController
{
    private readonly Dictionary<Guid, (ProductModel, int)> _productsDictionary;

    private readonly ILog _log = LogManager.GetLogger(typeof(ShopController));

    private readonly UserService _userService = UserService.Instance;
    private readonly CartService _cartService = CartService.Instance;

    public ShopController()
    {
        _productsDictionary = new Dictionary<Guid, (ProductModel, int)>();

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

        _productsDictionary.Add(book1.Id, (book1, 10));
        _productsDictionary.Add(book2.Id, (book2, 7));
        _productsDictionary.Add(shirt1.Id, (shirt1, 3));
        _productsDictionary.Add(shirt2.Id, (shirt2, 5));
        _productsDictionary.Add(table1.Id, (table1, 2));
        _productsDictionary.Add(table2.Id, (table2, 3));
    }

    public void Register()
    {
        try
        {
            Console.WriteLine("[REGISTRATION]\n");

            //Console.Write("Enter your email: ");
            //var email = Console.ReadLine();
            var email = "vlad@gmail.com";

            //Console.Write("Create a password: ");
            //var password = Console.ReadLine();
            var password = "123456";

            var user = _userService.Register(email, password);

            Console.WriteLine("The registration was successful!");
        }
        catch (ApplicationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void Login()
    {
        try
        {
            Console.WriteLine("[LOGIN]\n");

            Console.Write("Enter your email: ");
            var email = Console.ReadLine();

            Console.Write("Create a password: ");
            var password = Console.ReadLine();

            _userService.Login(email, password);
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
}