namespace SwitchPractice
{
    internal class Program
    {
        //switch分为基本switch、增强型switch、模式匹配switch 和 模式匹配+when子句，四种switch条件都是表达式
        //基本switch：case部分只能使用常量，执行逻辑比较独立
        //增强型switch：适用于简单的值映射和转换，需要返回一个值，而不是执行一系列操作
        //模式匹配switch：适用于根据对象的类型或结构进行匹配，需要处理不同类型的输入，并根据类型执行不同的操作
        //模式匹配 + when子句：适用于在模式匹配的基础上添加额外的条件，需要根据对象的类型和属性进行更复杂的匹配，需要在匹配条件中包含逻辑判断
        static void Main(string[] args)
        {
            int expression = 2;
            switch (expression)
            {
                case 1:
                    Console.WriteLine("One");
                    break;
                case 2:
                    Console.WriteLine("Two");
                    break;
                default:
                    Console.WriteLine("Other");
                    break;
            }

            Console.WriteLine("--------------------------");

            Console.WriteLine(expression switch
            {
                1 => "One",
                2 => "Two",
                _ => "Other"
            });

            Console.WriteLine("--------------------------");

            var inputs = new object[]
            {
                42,
                "Hello,World!",
                (5,"Hello"),
                new Exception("Something went wrong!"),
                null!,
                new {Name = "John",Age = 30 },
                3.14,
            };

            var name = inputs[5].GetType().Name;

            var results = inputs.Select(input => input switch
            {
                int i => $"It's an integer:{i}",
                string s when s.Length > 5 => $"It's a long string:{s}",
                (int x,string y) => $"It's a tuple with int {x} and string '{y}'",
                Exception ex => $"It's an exception:{ex.Message}",
                null => "It's null",
                var obj when obj.GetType().Name.Contains("AnonymousType") => "It's an anonymous object",
                double d when d > 3 => $"It's a double greater then 3 :{d}",
                _ => "Unknow type"
            });

            Console.WriteLine(string.Join(Environment.NewLine, results));
        }
    }
}
