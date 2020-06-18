using System;
using System.Collections.Generic;
using System.Text;

namespace Offer
{
    public sealed class SingletonWithDoubleCheck
    {
        /// <summary>
        /// 私有构造器确保类外部的代码无法实例化当前的类
        /// </summary>
        SingletonWithDoubleCheck()
        {
        }

        private static SingletonWithDoubleCheck instance = null;

        private static object syncObj = new object();

        public static SingletonWithDoubleCheck Instance
        {
            get
            {
                // 如果已经实例化,可以直接返回单例对象,不需要同步块同步
                if (instance == null)
                {
                    // 采用双检锁方式,确保实例化只进行一次
                    // <==如果有一个线程运行到此处,完成判断后被系统挂起,另一个线程抢先获得了锁并执行了实例化
                    // 那么等挂起的线程恢复运行后,并不知道另一个线程所做的工作,会第二次执行实例化
                    lock (syncObj)
                    {
                        // 为了防止这种情况,在同步块内部加入一个判断:因为同步块内部只允许一个线程进入,所以判断是线程安全的
                        if (instance == null)
                        {
                            instance = new SingletonWithDoubleCheck();
                        }
                    }
                }

                return instance;
            }
        }
    }

    public sealed class SingletonUsingStaticField
    {
        SingletonUsingStaticField()
        {
        }

        // 当代码第一次访问这个类的时候,运行时会初始化这个类的静态字段信息,这样确保只能有一个线程进行实例化
        private static SingletonUsingStaticField instance = new SingletonUsingStaticField();

        public static SingletonUsingStaticField Instance
        {
            get { return instance; }
        }
    }

    public sealed class SingletonWithNestedClass
    {
        SingletonWithNestedClass()
        {
        }

        public static SingletonWithNestedClass Instance
        {
            // 用另一个类做代理,这样在代码访问单例类的时候,可以暂时不实例化
            // 代码可以正常访问单例类中的其他属性或者方法,直到明确要求访问实例,才初始化
            get { return Nested.instance; }
        }

        private class Nested
        {
            internal static readonly SingletonWithNestedClass instance = new SingletonWithNestedClass();
        }
    }
}
