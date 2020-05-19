namespace Tests
{
    using Fixie;

    public class TestingConvention : Convention
    {
        public TestingConvention()
        {
            Classes
                .NameEndsWith("Tests");

            Methods
                .Where(method => method.IsVoid() || method.IsAsync());

            ClassExecution
                .CreateInstancePerCase();
        }
    }
}
