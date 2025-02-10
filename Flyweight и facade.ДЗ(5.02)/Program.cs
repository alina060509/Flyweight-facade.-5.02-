using System;
using Facade;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            var kitchen = new KitchenSystem();
            var delivery = new DeliverySystem();
            var payment = new PaymentSystem();

            var facade = new PizzaOrderFacade(kitchen, delivery, payment);
            facade.WatchMovi();
            Console.WriteLine("приятного аппетита....");

        }
    }

    public class KitchenSystem
    {
        public void PreparesPizza()
        {
            Console.WriteLine("Готовит пиццу!");
        }
        public void CollectsOrder()
        {
            Console.WriteLine("Собирает заказ!");
        }
    }
}
public class DeliverySystem
{
    public void Delivers()
    {
        Console.WriteLine("Доставляет заказ клиенту!");
    }
    public void WaitingPayment()
    {
        Console.WriteLine("Ждет оплаты!");
    }
}
public class PaymentSystem
{
    public void AcceptsPayment()
    {
        Console.WriteLine("Принимает оплату!");
    }
    public void PassedPayment()
    {
        Console.WriteLine("Оплата прошла!");
    }
}
public class PizzaOrderFacade
{
    private readonly KitchenSystem _kitchenSystem;
    private readonly DeliverySystem _deliverySystem;
    private readonly PaymentSystem _paymentSystem;

    public PizzaOrderFacade(KitchenSystem kitchen, DeliverySystem delivery, PaymentSystem payment)
    {
        _kitchenSystem = kitchen;
        _deliverySystem = delivery;
        _paymentSystem = payment;
    }

    public void WatchMovi()
    {
        _kitchenSystem.PreparesPizza();
        _kitchenSystem.CollectsOrder();
        _deliverySystem.Delivers();
        _deliverySystem.WaitingPayment();
        _paymentSystem.AcceptsPayment();
        _paymentSystem.PassedPayment();
    }
}
