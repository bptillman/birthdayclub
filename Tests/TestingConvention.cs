namespace Tests
{
    using Fixie;

    public class TestingConvention : Discovery, Execution
    {
        public TestingConvention()
        {
            Classes
                .Where(x => x.Name.EndsWith("Tests"));

            Methods
                .Where(method => method.IsVoid() || method.IsAsync());
        }

        public void Execute(TestClass testClass)
        {
            testClass.RunCases(@case =>
            {
                var instance = testClass.Construct();

                SetUp(instance);

                @case.Execute(instance);
            });
        }

        static void SetUp(object instance)
        {
            instance.GetType().GetMethod("SetUp")?.Execute(instance);
        }
    }
}
