using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Flower> flowers = new List<Flower>();
            for (int i = 0; i < 3; i++)
            {
                var FlowerType = FlowerFactory.GetTreeType("Тюльпан", "желтый", "мягкая кора");
                var FlowerType2 = FlowerFactory.GetTreeType("Ромашка", "белая", "мягко-шершавая кора");
                flowers.Add(new Flower(i * 15, i * 21, FlowerType));
                flowers.Add(new Flower(i * 16, i * 20, FlowerType2));
            }
            foreach (var tree in flowers)
            {
                tree.Display();
            }
        }
    }
    public class FlowerType
    {
        public string Name { get; }
        public string Color { get; }
        public string Texture { get; }

        public FlowerType(string name, string color, string texture)
        {
            Name = name;
            Color = color;
            Texture = texture;
        }
        public void Display(int x, int y)
        {
            Console.WriteLine($" Цветок с типом {Name} с цветом {Color} и текстурой {Texture} находитя на координатах({x},{y})");
        }
    }
    public class Flower
    {
        private readonly int _x;
        private readonly int _y;
        private readonly FlowerType _type;

        public Flower(int x, int y, FlowerType type)
        {
            _x = x;
            _y = y;
            _type = type;
        }
        public void Display()
        {
            _type.Display(_x, _y);

        }
    }
    public class FlowerFactory
    {
        private static readonly Dictionary<string, FlowerType> _flowerTypes = new Dictionary<string, FlowerType>();
        public static FlowerType GetTreeType(string name, string color, string texture)
        {
            string key = $"{name}_{color}_{texture}";
            if (!_flowerTypes.ContainsKey(key))
            {
                _flowerTypes[key] = new FlowerType(name, color, texture);
                Console.WriteLine($"Создан новый ключ: {key}");
            }
            return _flowerTypes[key];
        }
    }

}

