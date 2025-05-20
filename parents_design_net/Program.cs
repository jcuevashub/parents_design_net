// See https://aka.ms/new-console-template for more information

//Patroner Creacionales
//Estos patrones se centran en la creación de objetos, proporcionando mecanismos para instanciarlos de manera adecuada según el contexto.

//1. Singleton: Garantiza que una clase tenga una única instancia y proporciona un punto de acceso global a ella.
public sealed class Singleton
{
    private static Singleton instance = null;
    private static readonly object lockObject = new object();
    
    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }

                return instance;
            }
        }
    }
}

//2. Factory Method: Define una interfaz para crear un objeto, pero permite que las subclases decidan qué clase instanciar.
public interface IAnimal
{
    void Speak();
}

public class Dog: IAnimal
{
    public void Speak() => Console.WriteLine("Woof!");
}

class Cat : IAnimal
{
    public void Speak() => Console.WriteLine("Meow!");
}

public abstract class AnimalFactory
{
    public abstract IAnimal CreateAnimal();
}

public class DogFactory : AnimalFactory
{
    public override IAnimal CreateAnimal() => new Dog();
}

public class CatFactory : AnimalFactory
{
    public override IAnimal CreateAnimal() => new Cat();
}

//3. Builder: Separa la construcción de un objeto complejo de su representación, permitiendo crear diferentes representaciones con el mismo proceso de construcción.

public class Product
{
    public string PartA { get; set; }
    public string PartB { get; set; }
}

public abstract class Builder
{
    protected Product product = new Product();
    public abstract void BuildPartA();
    public abstract void BuildPartB();
    public Product GetResult() => product;
}

public class ConcreteBuilder : Builder
{
    public override void BuildPartA() => product.PartA = "PartA";
    public override void BuildPartB() => product.PartB = "PartB";
}

public class Director
{
    public Product Construct(Builder builder)
    {
        builder.BuildPartA();
        builder.BuildPartB();
        return builder.GetResult();
    }
}

//4. Dependency Injection: Permite inyectar las dependencias de una clase desde el exterior, promoviendo un acoplamiento débil y facilitando la prueba y mantenimiento del código.
public interface IService
{
    void Serve();
}

public class Service : IService
{
    public void Serve() => Console.WriteLine("Service Called");
}

public class Client
{
    private readonly IService _service;

    public Client(IService service)
    {
        _service = service;
    }

    public void Start() => _service.Serve();
}