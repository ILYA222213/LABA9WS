
class Program
{
    
    static void Main()
    {
        // Создаем два объекта класса Car с разными моделями
        Car car1 = new Car("Mercedes Benz");
        Car car2 = new Car("AUDI");

        // Создаем объект класса Garage
        Garage garage = new Garage();

        // Добавляем созданные автомобили в гараж
        garage.AddCar(car1);
        garage.AddCar(car2);

        // Создаем делегат для метода Wash класса Washer
        Action<Car> washDelegate = Washer.Wash;

        // Вызываем метод WashAllCars у объекта класса Garage, передавая в качестве аргумента делегат
        garage.WashAllCars(washDelegate);
    }
}

// Класс Car представляет собой автомобиль
public class Car
{
    // Свойство Model хранит модель автомобиля
    public string Model { get; set; }

    // Конструктор класса Car, который инициализирует свойство Model
    public Car(string model)
    {
        Model = model;
    }
}

// Класс Garage представляет собой гараж, где хранятся автомобили
public class Garage
{
    // Список для хранения автомобилей
    private List<Car> cars = new List<Car>();

    // Метод AddCar добавляет автомобиль в гараж
    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    // Метод WashAllCars вызывает для каждого автомобиля в гараже указанный метод 
    public void WashAllCars(Action<Car> washAction)
    {
        foreach (var car in cars)
        {
            washAction(car);
        }
    }
}

// Класс Washer содержит методы для работы с автомобилями
class Washer
{
    // Метод Wash выводит сообщение о том, что автомобиль отмыт
    public static void Wash(Car car)
    {
        Console.WriteLine($"отмыта {car.Model}.");
    }
}