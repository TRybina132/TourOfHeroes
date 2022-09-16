namespace TourOfHeroes.Middleware
{
    //  🌈 This one is called CONVENTION middleware - it doesn't
    //          implement any interfaces and scope of it is singleton
    //          it must contain public constuctor that accepts next middleware
    //          delegate and method Invoke that accepts httpcontext 💖
    //
    //  💞 As it is singleton we shouldn't inject anything with scoped or
    //          transient scope, (it will turn this instances into singleton)
    //          We can only pass them in invoke method 🦖
    public class CounterMiddleware
    {
        private static readonly object lockObject = new object();
        private readonly RequestDelegate next;
        private int count = 0;

        public CounterMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //  ᓚᘏᗢ So this is singelton we must make this operation thread safe
            Interlocked.Increment(ref count);
            await next(context);
            Console.WriteLine($"CALLS: {count}");
        }
    }
}
