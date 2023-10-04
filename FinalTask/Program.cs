namespace FinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем объекты продуктов
            Product product1 = new Product(1, "Apple", 10.0m);
            Product product2 = new Product(2, "Banana", 10.0m);
            Product product3 = new Product(3, "Pineappple", 10.0m);

            // Создаем менеджер заказов
            OrderManager<Delivery, Product> ordersManager = new OrderManager<Delivery, Product>();

            // Создаем заказы с разными типами доставки
            Order<Delivery, Product> TestOrder1 = new Order<Delivery, Product>();
            TestOrder1.Delivery = new HomeDelivery("Ул.Пушкина", "Григорий", "Курьер 1", "Позвонить заранее");
            TestOrder1.Description = "Тестовый заказ 1";

            Order<Delivery, Product> TestOrder2 = new Order<Delivery, Product>();
            TestOrder2.Delivery = new PickPointDelivery("Ул. Ленина", "Алиса", "Пункт выдачи 1");
            TestOrder2.Description = "Тестовый заказ 2";

            // Добавляем продукты в заказы
            TestOrder1.AddProduct(product1);
            TestOrder1.AddProduct(product2);
            TestOrder1.AddProduct(product3);

            TestOrder2.AddProduct(product1);
            TestOrder2.AddProduct(product3);

            // Добавляем заказы в менеджер
            ordersManager.AddOrder(TestOrder1);
            ordersManager.AddOrder(TestOrder2);

            // Отображаем все заказы
            ordersManager.DisplayOrders();

        }

        // Класс, представляющий продукт
        public class Product
        {
            private int productId;
            private string productName;
            private decimal price;

            public int ProductId
            {
                get { return productId; }
                set
                {
                    if (value < 0)
                    {
                        Console.WriteLine("ID продукта не может быть отрицательным");
                    }
                    else
                    {
                        productId = value;
                    }
                }
            }

            public string ProductName
            {
                get { return productName; }
                set
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        Console.WriteLine("Не задано имя товара");
                    }
                    else
                    {
                        productName = value;
                    }
                }
            }

            public decimal Price
            {
                get { return price; }
                set
                {
                    if (value < 0)
                    {
                        Console.WriteLine("Цена не может быть меньше 0");
                    }
                    else
                    {
                        price = value;
                    }
                }
            }

            public Product(int productId, string productName, decimal price)
            {
                //обращение к свойствам, а не к полям, для выполнения проверок
                ProductId = productId;
                ProductName = productName;
                Price = price;
            }
        }

        // Абстрактный класс, представляющий доставку
        abstract class Delivery
        {
            protected string address;
            protected string recipientName;

            public string Address
            {
                get { return address; }
                set
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        Console.WriteLine("Не задан адрес");
                    }
                    else
                    {
                        address = value;
                    }
                }
            }

            public string RecipientName
            {
                get { return recipientName; }
                set
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        Console.WriteLine("Не задано имя получателя");
                    }
                    else
                    {
                        recipientName = value;
                    }
                }
            }

            public Delivery(string address, string recipientName)
            {
                Address = address;
                RecipientName = recipientName;
            }

            // Абстрактный метод для получения информации о доставке
            public abstract string GetDeliveryInfo();

        }

        // Класс для доставки на дом
        class HomeDelivery : Delivery
        {
            private string CourierName;
            private string DeliveryInstructions;

            public HomeDelivery(string address, string recipientName, string courierName, string deliveryInstructions) : base(address, recipientName)
            {
                CourierName = courierName;
                DeliveryInstructions = deliveryInstructions;
            }

            public override string GetDeliveryInfo()
            {
                return $"Доставка на дом: Курьер: {CourierName}, Инструкции: {DeliveryInstructions}, Адрес: {address}, Получатель: {recipientName}";
            }

        }

        // Класс для доставки до пункта выдачи
        class PickPointDelivery : Delivery
        {
            private string PickPointName;

            public PickPointDelivery(string address, string recipientName, string pickPointName) : base(address, recipientName)
            {
                PickPointName = pickPointName;
            }

            public override string GetDeliveryInfo()
            {
                return $"Доставка до пункта выдачи: Адрес: {address}, Наименование пунтка выдачи: {PickPointName}, Получатель: {recipientName}";
            }
        }

        // Класс для доставки до магазина
        class ShopDelivery : Delivery
        {
            private string ShopName;

            public ShopDelivery(string address, string recipientName, string shopName) : base(address, recipientName)
            {
                ShopName = shopName;
            }

            public override string GetDeliveryInfo()
            {
                return $"Доставка до магазина: Адрес: {address}, Наименование магазина: {ShopName}, Получатель: {recipientName}";
            }
        }

        // Класс для управления заказами
        class Order<TDelivery, TProduct>
                where TDelivery : Delivery
                where TProduct : Product
        {
            public TDelivery Delivery;
            private int OrderNumber;
            private DateTime OrderTime;
            public string Description;
            private List<TProduct> OrderedProducts;

            //статическое поле, для хранения следующего номера заказа
            private static int nextOrderNumber = 1;

            public Order()
            {
                OrderedProducts = new List<TProduct>();
                OrderNumber = nextOrderNumber++;
                OrderTime = DateTime.Now;
            }

            public void AddProduct(TProduct product)
            {
                OrderedProducts.Add(product);
            }

            public void RemoveProduct(TProduct product)
            {
                OrderedProducts.Remove(product);
            }

            public decimal CalculateTotalPrice()
            {
                decimal total = 0;
                foreach (var product in OrderedProducts)
                {
                    total += product.Price;
                }
                return total;
            }

            // Метод для отображения информации о заказе
            public void DisplayOrder()
            {
                Console.WriteLine($"Номер заказа: {OrderNumber}, Дата заказа: {OrderTime}");
                Console.WriteLine(Description);
                Console.WriteLine(Delivery.GetDeliveryInfo());
                Console.WriteLine("Товары в заказе:");
                foreach (var product in OrderedProducts)
                {
                    Console.WriteLine($"Product ID: {product.ProductId}, Name: {product.ProductName}, Price: {product.Price}");
                }
                Console.WriteLine($"Итого: {CalculateTotalPrice()}");
            }
        }

        //Класс для управления списком заказов
        class OrderManager<TDelivery, TProduct>
                where TDelivery : Delivery
                where TProduct : Product
        {
            private List<Order<TDelivery, TProduct>> orders;

            public OrderManager()
            {
                orders = new List<Order<TDelivery, TProduct>>();
            }

            public void AddOrder(Order<TDelivery, TProduct> order)
            {
                orders.Add(order);
            }

            public void RemoveOrder(Order<TDelivery, TProduct> order)
            {
                orders.Remove(order);
            }

            public void DisplayOrders()
            {
                foreach (var order in orders)
                {
                    order.DisplayOrder();
                    Console.WriteLine();
                }
            }
        }
    }
}