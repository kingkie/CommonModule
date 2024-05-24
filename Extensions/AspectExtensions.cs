using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp.Infrastructure
{
    /// <summary>
    /// Aspect扩展方法
    /// </summary>
    public static class AspectExtensions
    {
        /// <summary>
        /// DoNothing
        /// </summary>
        [DebuggerStepThrough]
        public static void DoNothing()
        {

        }
        /// <summary>
        /// DoNothing
        /// </summary>
        /// <param name="whatever"></param>
        [DebuggerStepThrough]
        public static void DoNothing(params object[] whatever)
        {

        }
        /// <summary>
        /// 延迟
        /// </summary>
        /// <param name="aspect"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static AspectF Delay(this AspectF aspect, int milliseconds)
        {
            return aspect.Combine((work) =>
            {
                System.Threading.Thread.Sleep(milliseconds);
                work();
            });
        }
        /// <summary>
        /// MustBeNonNull
        /// </summary>
        /// <param name="aspect"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static AspectF MustBeNonNull(this AspectF aspect, params object[] args)
        {
            return aspect.Combine((work) =>
            {
                for (int i = 0; i < args.Length; i++)
                {
                    object arg = args[i];
                    if (arg == null)
                    {
                        throw new ArgumentException(string.Format("Parameter at index {0} is null", i));
                    }
                }
                work();
            });
        }
        /// <summary>
        /// MustBeNonDefault
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="aspect"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static AspectF MustBeNonDefault<T>(this AspectF aspect, params T[] args) where T : IComparable
        {
            return aspect.Combine((work) =>
            {
                T defaultvalue = default(T);
                for (int i = 0; i < args.Length; i++)
                {
                    T arg = args[i];
                    if (arg == null || arg.Equals(defaultvalue))
                    {
                        throw new ArgumentException(string.Format("Parameter at index {0} is null", i));
                    }
                }
                work();
            });
        }
        /// <summary>
        /// WhenTrue
        /// </summary>
        /// <param name="aspect"></param>
        /// <param name="conditions"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static AspectF WhenTrue(this AspectF aspect, params Func<bool>[] conditions)
        {
            return aspect.Combine((work) =>
            {
                foreach (Func<bool> condition in conditions)
                {
                    if (!condition())
                    {
                        return;
                    }
                }
                work();
            });
        }
        /// <summary>
        /// 运行
        /// </summary>
        /// <param name="aspect"></param>
        /// <param name="completeCallback"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static AspectF RunAsync(this AspectF aspect, Action completeCallback)
        {
            return aspect.Combine((work) => work.BeginInvoke(asyncresult =>
            {
                work.EndInvoke(asyncresult); completeCallback();
            }, null));
        }
        /// <summary>
        /// 运行
        /// </summary>
        /// <param name="aspect"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static AspectF RunAsync(this AspectF aspect)
        {
            return aspect.Combine((work) => work.BeginInvoke(asyncresult =>
            {
                work.EndInvoke(asyncresult);
            }, null));
        }
        /// <summary>
        /// 重试
        /// </summary>
        /// <param name="aspects"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static AspectF Retry(this AspectF aspects)
        {
            return aspects.Combine((work) =>
                Retry(1000, 1, (error) => DoNothing(error), DoNothing, work));
        }
        /// <summary>
        /// 重试
        /// </summary>
        /// <param name="retryDuration"></param>
        /// <param name="retryCount"></param>
        /// <param name="errorHandler"></param>
        /// <param name="retryFailed"></param>
        /// <param name="work"></param>
        [DebuggerStepThrough]
        public static void Retry(int retryDuration, int retryCount,
            Action<Exception> errorHandler, Action retryFailed, Action work)
        {
            do
            {
                try
                {
                    work();
                }
                catch (Exception x)
                {
                    errorHandler(x);
                    System.Threading.Thread.Sleep(retryDuration);
                }
            } while (retryCount-- > 0);
            retryFailed();
        }
    }
}
