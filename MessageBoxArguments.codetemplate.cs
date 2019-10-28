using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace System.Windows.Forms
{
    sealed partial class MessageBoxArguments
    {
        

        /// <summary>
        /// 将此实例转换为包含 <see cref="MessageBoxButtons.OK"/> 操作的实例。
        /// </summary>
        /// <returns>返回 <see cref="IOKBehavior"/> 实例。</returns>
        public IOKBehavior AsOKBehavior()
        {
            return new OKBehavior(new MessageBoxBehavior(this));
        }

        /// <summary>
        /// 将此实例转换为包含 <see cref="MessageBoxButtons.OK"/> 操作的实例。
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <returns>返回 <see cref="IOKBehavior"/> 实例。</returns>
        public IOKBehavior<T> AsOKBehavior<T>()
        {
            return new OKBehavior<T>(new MessageBoxBehavior(this));
        }

        /// <summary>
        /// 定义一个包含 <see cref="MessageBoxButtons.OK"/> 按钮的操作。
        /// Implements the <see cref="MessageCollector.IMessageBoxBehavior" />
        /// </summary>
        /// <seealso cref="MessageCollector.IMessageBoxBehavior" />
        public interface IOKBehavior : IMessageBoxBehavior
        {
                                    /// <summary>
            /// 指定当任意 <see cref="MessageBox"/>.Show 返回结果为 <see cref="DialogResult.OK"/> 时，执行的方法。
            /// </summary>
            /// <param name="Behavior">执行的方法。</param>
            /// <returns>返回设置后的 <see cref="IOKBehavior"/> 实例。</returns>
            IOKBehavior OnOK(Action action);
            /// <summary>
            /// 设置 OK 按钮显示的文本内容。
            /// </summary>
            /// <param name="text">文本内容。</param>
            /// <returns>返回 <see cref="IOKBehavior"/> 实例。</returns>
            IOKBehavior SetOKText(string text);
                                                                                            }
        /// <summary>
        /// 定义一个包含 <see cref="MessageBoxButtons.OK"/> 按钮，且返回指定类型 <typeparamref name="T"/> 值的操作。
        /// Implements the <see cref="MessageCollector.IMessageBoxBehavior{T}" />
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <seealso cref="MessageCollector.IMessageBoxBehavior{T}" />
        public interface IOKBehavior<T>:IMessageBoxBehavior<T>
        { 
                                    /// <summary>
            /// 指定当任意 <see cref="MessageBox"/>.Show 返回结果为 <see cref="DialogResult.OK"/> 时，执行的方法。
            /// </summary>
            /// <param name="func">执行的方法。</param>
            /// <returns>返回设置后的 <see cref="IOKBehavior&lt;T&gt;"/> 实例。</returns>
            IOKBehavior<T> OnOK(Func<T> func);
            /// <summary>
            /// 设置 OK 按钮显示的文本内容。
            /// </summary>
            /// <param name="text">文本内容。</param>
            /// <returns>返回 <see cref="IOKBehavior&lt;T&gt;"/> 实例。</returns>
            IOKBehavior<T> SetOKText(string text);
                                                                                            }

          class OKBehavior: IOKBehavior
        {
            private readonly MessageBoxBehavior behavior;
            
                public OKBehavior(MessageBoxBehavior behavior){this.behavior=behavior;}
            
                                        public  IOKBehavior OnOK(Action action)
                {
                    behavior.Add(DialogResult.OK, action);
                    return this;
                }
                public IOKBehavior SetOKText(string text)
                {
                    behavior.AddText(DialogResult.OK, text);
                    return this;
                }
                                                                                                    public void Show()
                { 
                    behavior.Invoke(MessageBoxButtons.OK, null);
                }
        }
        class OKBehavior<T>:IOKBehavior<T>
        { 
            private readonly MessageBoxBehavior behavior;
            public OKBehavior(MessageBoxBehavior behavior){this.behavior=behavior; }
                                        public  IOKBehavior<T> OnOK(Func<T> func)
                {
                    behavior.Add(DialogResult.OK, func);
                    return this;
                }
                public IOKBehavior<T> SetOKText(string text)
                {
                    behavior.AddText(DialogResult.OK, text);
                    return this;
                }
                                                                                                public T Show()
            {
            return (T)behavior.Invoke(MessageBoxButtons.OK, default);
            }
        }
   
        /// <summary>
        /// 将此实例转换为包含 <see cref="MessageBoxButtons.OKCancel"/> 操作的实例。
        /// </summary>
        /// <returns>返回 <see cref="IOKCancelBehavior"/> 实例。</returns>
        public IOKCancelBehavior AsOKCancelBehavior()
        {
            return new OKCancelBehavior(new MessageBoxBehavior(this));
        }

        /// <summary>
        /// 将此实例转换为包含 <see cref="MessageBoxButtons.OKCancel"/> 操作的实例。
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <returns>返回 <see cref="IOKCancelBehavior"/> 实例。</returns>
        public IOKCancelBehavior<T> AsOKCancelBehavior<T>()
        {
            return new OKCancelBehavior<T>(new MessageBoxBehavior(this));
        }

        /// <summary>
        /// 定义一个包含 <see cref="MessageBoxButtons.OKCancel"/> 按钮的操作。
        /// Implements the <see cref="MessageCollector.IMessageBoxBehavior" />
        /// </summary>
        /// <seealso cref="MessageCollector.IMessageBoxBehavior" />
        public interface IOKCancelBehavior : IMessageBoxBehavior
        {
                                    /// <summary>
            /// 指定当任意 <see cref="MessageBox"/>.Show 返回结果为 <see cref="DialogResult.OK"/> 时，执行的方法。
            /// </summary>
            /// <param name="Behavior">执行的方法。</param>
            /// <returns>返回设置后的 <see cref="IOKCancelBehavior"/> 实例。</returns>
            IOKCancelBehavior OnOK(Action action);
            /// <summary>
            /// 设置 OK 按钮显示的文本内容。
            /// </summary>
            /// <param name="text">文本内容。</param>
            /// <returns>返回 <see cref="IOKBehavior"/> 实例。</returns>
            IOKCancelBehavior SetOKText(string text);
                                                                        /// <summary>
            /// 指定当任意 <see cref="MessageBox"/>.Show 返回结果为 <see cref="DialogResult.Cancel"/> 时，执行的方法。
            /// </summary>
            /// <param name="Behavior">执行的方法。</param>
            /// <returns>返回设置后的 <see cref="IOKCancelBehavior"/> 实例。</returns>
            IOKCancelBehavior OnCancel(Action action);
            /// <summary>
            /// 设置 Cancel 按钮显示的文本内容。
            /// </summary>
            /// <param name="text">文本内容。</param>
            /// <returns>返回 <see cref="IOKBehavior"/> 实例。</returns>
            IOKCancelBehavior SetCancelText(string text);
                                            }
        /// <summary>
        /// 定义一个包含 <see cref="MessageBoxButtons.OKCancel"/> 按钮，且返回指定类型 <typeparamref name="T"/> 值的操作。
        /// Implements the <see cref="MessageCollector.IMessageBoxBehavior{T}" />
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <seealso cref="MessageCollector.IMessageBoxBehavior{T}" />
        public interface IOKCancelBehavior<T>:IMessageBoxBehavior<T>
        { 
                                    /// <summary>
            /// 指定当任意 <see cref="MessageBox"/>.Show 返回结果为 <see cref="DialogResult.OK"/> 时，执行的方法。
            /// </summary>
            /// <param name="func">执行的方法。</param>
            /// <returns>返回设置后的 <see cref="IOKBehavior&lt;T&gt;"/> 实例。</returns>
            IOKCancelBehavior<T> OnOK(Func<T> func);
            /// <summary>
            /// 设置 OK 按钮显示的文本内容。
            /// </summary>
            /// <param name="text">文本内容。</param>
            /// <returns>返回 <see cref="IOKBehavior&lt;T&gt;"/> 实例。</returns>
            IOKCancelBehavior<T> SetOKText(string text);
                                                                        /// <summary>
            /// 指定当任意 <see cref="MessageBox"/>.Show 返回结果为 <see cref="DialogResult.Cancel"/> 时，执行的方法。
            /// </summary>
            /// <param name="func">执行的方法。</param>
            /// <returns>返回设置后的 <see cref="IOKBehavior&lt;T&gt;"/> 实例。</returns>
            IOKCancelBehavior<T> OnCancel(Func<T> func);
            /// <summary>
            /// 设置 Cancel 按钮显示的文本内容。
            /// </summary>
            /// <param name="text">文本内容。</param>
            /// <returns>返回 <see cref="IOKBehavior&lt;T&gt;"/> 实例。</returns>
            IOKCancelBehavior<T> SetCancelText(string text);
                                            }

          class OKCancelBehavior: IOKCancelBehavior
        {
            private readonly MessageBoxBehavior behavior;
            
                public OKCancelBehavior(MessageBoxBehavior behavior){this.behavior=behavior;}
            
                                        public  IOKCancelBehavior OnOK(Action action)
                {
                    behavior.Add(DialogResult.OK, action);
                    return this;
                }
                public IOKCancelBehavior SetOKText(string text)
                {
                    behavior.AddText(DialogResult.OK, text);
                    return this;
                }
                                                                            public  IOKCancelBehavior OnCancel(Action action)
                {
                    behavior.Add(DialogResult.Cancel, action);
                    return this;
                }
                public IOKCancelBehavior SetCancelText(string text)
                {
                    behavior.AddText(DialogResult.Cancel, text);
                    return this;
                }
                                                    public void Show()
                { 
                    behavior.Invoke(MessageBoxButtons.OKCancel, null);
                }
        }
        class OKCancelBehavior<T>:IOKCancelBehavior<T>
        { 
            private readonly MessageBoxBehavior behavior;
            public OKCancelBehavior(MessageBoxBehavior behavior){this.behavior=behavior; }
                                        public  IOKCancelBehavior<T> OnOK(Func<T> func)
                {
                    behavior.Add(DialogResult.OK, func);
                    return this;
                }
                public IOKCancelBehavior<T> SetOKText(string text)
                {
                    behavior.AddText(DialogResult.OK, text);
                    return this;
                }
                                                                            public  IOKCancelBehavior<T> OnCancel(Func<T> func)
                {
                    behavior.Add(DialogResult.Cancel, func);
                    return this;
                }
                public IOKCancelBehavior<T> SetCancelText(string text)
                {
                    behavior.AddText(DialogResult.Cancel, text);
                    return this;
                }
                                                public T Show()
            {
            return (T)behavior.Invoke(MessageBoxButtons.OKCancel, default);
            }
        }
   
        /// <summary>
        /// 将此实例转换为包含 <see cref="MessageBoxButtons.AbortRetryIgnore"/> 操作的实例。
        /// </summary>
        /// <returns>返回 <see cref="IAbortRetryIgnoreBehavior"/> 实例。</returns>
        public IAbortRetryIgnoreBehavior AsAbortRetryIgnoreBehavior()
        {
            return new AbortRetryIgnoreBehavior(new MessageBoxBehavior(this));
        }

        /// <summary>
        /// 将此实例转换为包含 <see cref="MessageBoxButtons.AbortRetryIgnore"/> 操作的实例。
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <returns>返回 <see cref="IAbortRetryIgnoreBehavior"/> 实例。</returns>
        public IAbortRetryIgnoreBehavior<T> AsAbortRetryIgnoreBehavior<T>()
        {
            return new AbortRetryIgnoreBehavior<T>(new MessageBoxBehavior(this));
        }

        /// <summary>
        /// 定义一个包含 <see cref="MessageBoxButtons.AbortRetryIgnore"/> 按钮的操作。
        /// Implements the <see cref="MessageCollector.IMessageBoxBehavior" />
        /// </summary>
        /// <seealso cref="MessageCollector.IMessageBoxBehavior" />
        public interface IAbortRetryIgnoreBehavior : IMessageBoxBehavior
        {
                                                                        /// <summary>
            /// 指定当任意 <see cref="MessageBox"/>.Show 返回结果为 <see cref="DialogResult.Abort"/> 时，执行的方法。
            /// </summary>
            /// <param name="Behavior">执行的方法。</param>
            /// <returns>返回设置后的 <see cref="IAbortRetryIgnoreBehavior"/> 实例。</returns>
            IAbortRetryIgnoreBehavior OnAbort(Action action);
            /// <summary>
            /// 设置 Abort 按钮显示的文本内容。
            /// </summary>
            /// <param name="text">文本内容。</param>
            /// <returns>返回 <see cref="IOKBehavior"/> 实例。</returns>
            IAbortRetryIgnoreBehavior SetAbortText(string text);
                                                /// <summary>
            /// 指定当任意 <see cref="MessageBox"/>.Show 返回结果为 <see cref="DialogResult.Retry"/> 时，执行的方法。
            /// </summary>
            /// <param name="Behavior">执行的方法。</param>
            /// <returns>返回设置后的 <see cref="IAbortRetryIgnoreBehavior"/> 实例。</returns>
            IAbortRetryIgnoreBehavior OnRetry(Action action);
            /// <summary>
            /// 设置 Retry 按钮显示的文本内容。
            /// </summary>
            /// <param name="text">文本内容。</param>
            /// <returns>返回 <see cref="IOKBehavior"/> 实例。</returns>
            IAbortRetryIgnoreBehavior SetRetryText(string text);
                                    /// <summary>
            /// 指定当任意 <see cref="MessageBox"/>.Show 返回结果为 <see cref="DialogResult.Ignore"/> 时，执行的方法。
            /// </summary>
            /// <param name="Behavior">执行的方法。</param>
            /// <returns>返回设置后的 <see cref="IAbortRetryIgnoreBehavior"/> 实例。</returns>
            IAbortRetryIgnoreBehavior OnIgnore(Action action);
            /// <summary>
            /// 设置 Ignore 按钮显示的文本内容。
            /// </summary>
            /// <param name="text">文本内容。</param>
            /// <returns>返回 <see cref="IOKBehavior"/> 实例。</returns>
            IAbortRetryIgnoreBehavior SetIgnoreText(string text);
                    }
        /// <summary>
        /// 定义一个包含 <see cref="MessageBoxButtons.AbortRetryIgnore"/> 按钮，且返回指定类型 <typeparamref name="T"/> 值的操作。
        /// Implements the <see cref="MessageCollector.IMessageBoxBehavior{T}" />
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <seealso cref="MessageCollector.IMessageBoxBehavior{T}" />
        public interface IAbortRetryIgnoreBehavior<T>:IMessageBoxBehavior<T>
        { 
                                                                        /// <summary>
            /// 指定当任意 <see cref="MessageBox"/>.Show 返回结果为 <see cref="DialogResult.Abort"/> 时，执行的方法。
            /// </summary>
            /// <param name="func">执行的方法。</param>
            /// <returns>返回设置后的 <see cref="IOKBehavior&lt;T&gt;"/> 实例。</returns>
            IAbortRetryIgnoreBehavior<T> OnAbort(Func<T> func);
            /// <summary>
            /// 设置 Abort 按钮显示的文本内容。
            /// </summary>
            /// <param name="text">文本内容。</param>
            /// <returns>返回 <see cref="IOKBehavior&lt;T&gt;"/> 实例。</returns>
            IAbortRetryIgnoreBehavior<T> SetAbortText(string text);
                                                /// <summary>
            /// 指定当任意 <see cref="MessageBox"/>.Show 返回结果为 <see cref="DialogResult.Retry"/> 时，执行的方法。
            /// </summary>
            /// <param name="func">执行的方法。</param>
            /// <returns>返回设置后的 <see cref="IOKBehavior&lt;T&gt;"/> 实例。</returns>
            IAbortRetryIgnoreBehavior<T> OnRetry(Func<T> func);
            /// <summary>
            /// 设置 Retry 按钮显示的文本内容。
            /// </summary>
            /// <param name="text">文本内容。</param>
            /// <returns>返回 <see cref="IOKBehavior&lt;T&gt;"/> 实例。</returns>
            IAbortRetryIgnoreBehavior<T> SetRetryText(string text);
                                    /// <summary>
            /// 指定当任意 <see cref="MessageBox"/>.Show 返回结果为 <see cref="DialogResult.Ignore"/> 时，执行的方法。
            /// </summary>
            /// <param name="func">执行的方法。</param>
            /// <returns>返回设置后的 <see cref="IOKBehavior&lt;T&gt;"/> 实例。</returns>
            IAbortRetryIgnoreBehavior<T> OnIgnore(Func<T> func);
            /// <summary>
            /// 设置 Ignore 按钮显示的文本内容。
            /// </summary>
            /// <param name="text">文本内容。</param>
            /// <returns>返回 <see cref="IOKBehavior&lt;T&gt;"/> 实例。</returns>
            IAbortRetryIgnoreBehavior<T> SetIgnoreText(string text);
                    }

          class AbortRetryIgnoreBehavior: IAbortRetryIgnoreBehavior
        {
            private readonly MessageBoxBehavior behavior;
            
                public AbortRetryIgnoreBehavior(MessageBoxBehavior behavior){this.behavior=behavior;}
            
                                                                public  IAbortRetryIgnoreBehavior OnNo(Action action)
                {
                    behavior.Add(DialogResult.No, action);
                    return this;
                }
                public IAbortRetryIgnoreBehavior SetNoText(string text)
                {
                    behavior.AddText(DialogResult.No, text);
                    return this;
                }
                                        public  IAbortRetryIgnoreBehavior OnAbort(Action action)
                {
                    behavior.Add(DialogResult.Abort, action);
                    return this;
                }
                public IAbortRetryIgnoreBehavior SetAbortText(string text)
                {
                    behavior.AddText(DialogResult.Abort, text);
                    return this;
                }
                                                    public  IAbortRetryIgnoreBehavior OnRetry(Action action)
                {
                    behavior.Add(DialogResult.Retry, action);
                    return this;
                }
                public IAbortRetryIgnoreBehavior SetRetryText(string text)
                {
                    behavior.AddText(DialogResult.Retry, text);
                    return this;
                }
                                        public  IAbortRetryIgnoreBehavior OnIgnore(Action action)
                {
                    behavior.Add(DialogResult.Ignore, action);
                    return this;
                }
                public IAbortRetryIgnoreBehavior SetIgnoreText(string text)
                {
                    behavior.AddText(DialogResult.Ignore, text);
                    return this;
                }
                            public void Show()
                { 
                    behavior.Invoke(MessageBoxButtons.AbortRetryIgnore, null);
                }
        }
        class AbortRetryIgnoreBehavior<T>:IAbortRetryIgnoreBehavior<T>
        { 
            private readonly MessageBoxBehavior behavior;
            public AbortRetryIgnoreBehavior(MessageBoxBehavior behavior){this.behavior=behavior; }
                                                                public  IAbortRetryIgnoreBehavior<T> OnNo(Func<T> func)
                {
                    behavior.Add(DialogResult.No, func);
                    return this;
                }
                public IAbortRetryIgnoreBehavior<T> SetNoText(string text)
                {
                    behavior.AddText(DialogResult.No, text);
                    return this;
                }
                                        public  IAbortRetryIgnoreBehavior<T> OnAbort(Func<T> func)
                {
                    behavior.Add(DialogResult.Abort, func);
                    return this;
                }
                public IAbortRetryIgnoreBehavior<T> SetAbortText(string text)
                {
                    behavior.AddText(DialogResult.Abort, text);
                    return this;
                }
                                                    public  IAbortRetryIgnoreBehavior<T> OnRetry(Func<T> func)
                {
                    behavior.Add(DialogResult.Retry, func);
                    return this;
                }
                public IAbortRetryIgnoreBehavior<T> SetRetryText(string text)
                {
                    behavior.AddText(DialogResult.Retry, text);
                    return this;
                }
                                        public  IAbortRetryIgnoreBehavior<T> OnIgnore(Func<T> func)
                {
                    behavior.Add(DialogResult.Ignore, func);
                    return this;
                }
                public IAbortRetryIgnoreBehavior<T> SetIgnoreText(string text)
                {
                    behavior.AddText(DialogResult.Ignore, text);
                    return this;
                }
                        public T Show()
            {
            return (T)behavior.Invoke(MessageBoxButtons.AbortRetryIgnore, default);
            }
        }
   
        /// <summary>
        /// 将此实例转换为包含 <see cref="MessageBoxButtons.YesNoCancel"/> 操作的实例。
        /// </summary>
        /// <returns>返回 <see cref="IYesNoCancelBehavior"/> 实例。</returns>
        public IYesNoCancelBehavior AsYesNoCancelBehavior()
        {
            return new YesNoCancelBehavior(new MessageBoxBehavior(this));
        }

        /// <summary>
        /// 将此实例转换为包含 <see cref="MessageBoxButtons.YesNoCancel"/> 操作的实例。
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <returns>返回 <see cref="IYesNoCancelBehavior"/> 实例。</returns>
        public IYesNoCancelBehavior<T> AsYesNoCancelBehavior<T>()
        {
            return new YesNoCancelBehavior<T>(new MessageBoxBehavior(this));
        }

        /// <summary>
        /// 定义一个包含 <see cref="MessageBoxButtons.YesNoCancel"/> 按钮的操作。
        /// Implements the <see cref="MessageCollector.IMessageBoxBehavior" />
        /// </summary>
        /// <seealso cref="MessageCollector.IMessageBoxBehavior" />
        public interface IYesNoCancelBehavior : IMessageBoxBehavior
        {
                                                /// <summary>
            /// 指定当任意 <see cref="MessageBox"/>.Show 返回结果为 <see cref="DialogResult.Yes"/> 时，执行的方法。
            /// </summary>
            /// <param name="Behavior">执行的方法。</param>
            /// <returns>返回设置后的 <see cref="IYesNoCancelBehavior"/> 实例。</returns>
            IYesNoCancelBehavior OnYes(Action action);
            /// <summary>
            /// 设置 Yes 按钮显示的文本内容。
            /// </summary>
            /// <param name="text">文本内容。</param>
            /// <returns>返回 <see cref="IOKBehavior"/> 实例。</returns>
            IYesNoCancelBehavior SetYesText(string text);
                                    /// <summary>
            /// 指定当任意 <see cref="MessageBox"/>.Show 返回结果为 <see cref="DialogResult.No"/> 时，执行的方法。
            /// </summary>
            /// <param name="Behavior">执行的方法。</param>
            /// <returns>返回设置后的 <see cref="IYesNoCancelBehavior"/> 实例。</returns>
            IYesNoCancelBehavior OnNo(Action action);
            /// <summary>
            /// 设置 No 按钮显示的文本内容。
            /// </summary>
            /// <param name="text">文本内容。</param>
            /// <returns>返回 <see cref="IOKBehavior"/> 实例。</returns>
            IYesNoCancelBehavior SetNoText(string text);
                                                /// <summary>
            /// 指定当任意 <see cref="MessageBox"/>.Show 返回结果为 <see cref="DialogResult.Cancel"/> 时，执行的方法。
            /// </summary>
            /// <param name="Behavior">执行的方法。</param>
            /// <returns>返回设置后的 <see cref="IYesNoCancelBehavior"/> 实例。</returns>
            IYesNoCancelBehavior OnCancel(Action action);
            /// <summary>
            /// 设置 Cancel 按钮显示的文本内容。
            /// </summary>
            /// <param name="text">文本内容。</param>
            /// <returns>返回 <see cref="IOKBehavior"/> 实例。</returns>
            IYesNoCancelBehavior SetCancelText(string text);
                                            }
        /// <summary>
        /// 定义一个包含 <see cref="MessageBoxButtons.YesNoCancel"/> 按钮，且返回指定类型 <typeparamref name="T"/> 值的操作。
        /// Implements the <see cref="MessageCollector.IMessageBoxBehavior{T}" />
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <seealso cref="MessageCollector.IMessageBoxBehavior{T}" />
        public interface IYesNoCancelBehavior<T>:IMessageBoxBehavior<T>
        { 
                                                /// <summary>
            /// 指定当任意 <see cref="MessageBox"/>.Show 返回结果为 <see cref="DialogResult.Yes"/> 时，执行的方法。
            /// </summary>
            /// <param name="func">执行的方法。</param>
            /// <returns>返回设置后的 <see cref="IOKBehavior&lt;T&gt;"/> 实例。</returns>
            IYesNoCancelBehavior<T> OnYes(Func<T> func);
            /// <summary>
            /// 设置 Yes 按钮显示的文本内容。
            /// </summary>
            /// <param name="text">文本内容。</param>
            /// <returns>返回 <see cref="IOKBehavior&lt;T&gt;"/> 实例。</returns>
            IYesNoCancelBehavior<T> SetYesText(string text);
                                    /// <summary>
            /// 指定当任意 <see cref="MessageBox"/>.Show 返回结果为 <see cref="DialogResult.No"/> 时，执行的方法。
            /// </summary>
            /// <param name="func">执行的方法。</param>
            /// <returns>返回设置后的 <see cref="IOKBehavior&lt;T&gt;"/> 实例。</returns>
            IYesNoCancelBehavior<T> OnNo(Func<T> func);
            /// <summary>
            /// 设置 No 按钮显示的文本内容。
            /// </summary>
            /// <param name="text">文本内容。</param>
            /// <returns>返回 <see cref="IOKBehavior&lt;T&gt;"/> 实例。</returns>
            IYesNoCancelBehavior<T> SetNoText(string text);
                                                /// <summary>
            /// 指定当任意 <see cref="MessageBox"/>.Show 返回结果为 <see cref="DialogResult.Cancel"/> 时，执行的方法。
            /// </summary>
            /// <param name="func">执行的方法。</param>
            /// <returns>返回设置后的 <see cref="IOKBehavior&lt;T&gt;"/> 实例。</returns>
            IYesNoCancelBehavior<T> OnCancel(Func<T> func);
            /// <summary>
            /// 设置 Cancel 按钮显示的文本内容。
            /// </summary>
            /// <param name="text">文本内容。</param>
            /// <returns>返回 <see cref="IOKBehavior&lt;T&gt;"/> 实例。</returns>
            IYesNoCancelBehavior<T> SetCancelText(string text);
                                            }

          class YesNoCancelBehavior: IYesNoCancelBehavior
        {
            private readonly MessageBoxBehavior behavior;
            
                public YesNoCancelBehavior(MessageBoxBehavior behavior){this.behavior=behavior;}
            
                                                    public  IYesNoCancelBehavior OnYes(Action action)
                {
                    behavior.Add(DialogResult.Yes, action);
                    return this;
                }
                public IYesNoCancelBehavior SetYesText(string text)
                {
                    behavior.AddText(DialogResult.Yes, text);
                    return this;
                }
                                        public  IYesNoCancelBehavior OnNo(Action action)
                {
                    behavior.Add(DialogResult.No, action);
                    return this;
                }
                public IYesNoCancelBehavior SetNoText(string text)
                {
                    behavior.AddText(DialogResult.No, text);
                    return this;
                }
                                                    public  IYesNoCancelBehavior OnCancel(Action action)
                {
                    behavior.Add(DialogResult.Cancel, action);
                    return this;
                }
                public IYesNoCancelBehavior SetCancelText(string text)
                {
                    behavior.AddText(DialogResult.Cancel, text);
                    return this;
                }
                                                    public void Show()
                { 
                    behavior.Invoke(MessageBoxButtons.YesNoCancel, null);
                }
        }
        class YesNoCancelBehavior<T>:IYesNoCancelBehavior<T>
        { 
            private readonly MessageBoxBehavior behavior;
            public YesNoCancelBehavior(MessageBoxBehavior behavior){this.behavior=behavior; }
                                                    public  IYesNoCancelBehavior<T> OnYes(Func<T> func)
                {
                    behavior.Add(DialogResult.Yes, func);
                    return this;
                }
                public IYesNoCancelBehavior<T> SetYesText(string text)
                {
                    behavior.AddText(DialogResult.Yes, text);
                    return this;
                }
                                        public  IYesNoCancelBehavior<T> OnNo(Func<T> func)
                {
                    behavior.Add(DialogResult.No, func);
                    return this;
                }
                public IYesNoCancelBehavior<T> SetNoText(string text)
                {
                    behavior.AddText(DialogResult.No, text);
                    return this;
                }
                                                    public  IYesNoCancelBehavior<T> OnCancel(Func<T> func)
                {
                    behavior.Add(DialogResult.Cancel, func);
                    return this;
                }
                public IYesNoCancelBehavior<T> SetCancelText(string text)
                {
                    behavior.AddText(DialogResult.Cancel, text);
                    return this;
                }
                                                public T Show()
            {
            return (T)behavior.Invoke(MessageBoxButtons.YesNoCancel, default);
            }
        }
   
        /// <summary>
        /// 将此实例转换为包含 <see cref="MessageBoxButtons.YesNo"/> 操作的实例。
        /// </summary>
        /// <returns>返回 <see cref="IYesNoBehavior"/> 实例。</returns>
        public IYesNoBehavior AsYesNoBehavior()
        {
            return new YesNoBehavior(new MessageBoxBehavior(this));
        }

        /// <summary>
        /// 将此实例转换为包含 <see cref="MessageBoxButtons.YesNo"/> 操作的实例。
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <returns>返回 <see cref="IYesNoBehavior"/> 实例。</returns>
        public IYesNoBehavior<T> AsYesNoBehavior<T>()
        {
            return new YesNoBehavior<T>(new MessageBoxBehavior(this));
        }

        /// <summary>
        /// 定义一个包含 <see cref="MessageBoxButtons.YesNo"/> 按钮的操作。
        /// Implements the <see cref="MessageCollector.IMessageBoxBehavior" />
        /// </summary>
        /// <seealso cref="MessageCollector.IMessageBoxBehavior" />
        public interface IYesNoBehavior : IMessageBoxBehavior
        {
                                                /// <summary>
            /// 指定当任意 <see cref="MessageBox"/>.Show 返回结果为 <see cref="DialogResult.Yes"/> 时，执行的方法。
            /// </summary>
            /// <param name="Behavior">执行的方法。</param>
            /// <returns>返回设置后的 <see cref="IYesNoBehavior"/> 实例。</returns>
            IYesNoBehavior OnYes(Action action);
            /// <summary>
            /// 设置 Yes 按钮显示的文本内容。
            /// </summary>
            /// <param name="text">文本内容。</param>
            /// <returns>返回 <see cref="IOKBehavior"/> 实例。</returns>
            IYesNoBehavior SetYesText(string text);
                                    /// <summary>
            /// 指定当任意 <see cref="MessageBox"/>.Show 返回结果为 <see cref="DialogResult.No"/> 时，执行的方法。
            /// </summary>
            /// <param name="Behavior">执行的方法。</param>
            /// <returns>返回设置后的 <see cref="IYesNoBehavior"/> 实例。</returns>
            IYesNoBehavior OnNo(Action action);
            /// <summary>
            /// 设置 No 按钮显示的文本内容。
            /// </summary>
            /// <param name="text">文本内容。</param>
            /// <returns>返回 <see cref="IOKBehavior"/> 实例。</returns>
            IYesNoBehavior SetNoText(string text);
                                                                    }
        /// <summary>
        /// 定义一个包含 <see cref="MessageBoxButtons.YesNo"/> 按钮，且返回指定类型 <typeparamref name="T"/> 值的操作。
        /// Implements the <see cref="MessageCollector.IMessageBoxBehavior{T}" />
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <seealso cref="MessageCollector.IMessageBoxBehavior{T}" />
        public interface IYesNoBehavior<T>:IMessageBoxBehavior<T>
        { 
                                                /// <summary>
            /// 指定当任意 <see cref="MessageBox"/>.Show 返回结果为 <see cref="DialogResult.Yes"/> 时，执行的方法。
            /// </summary>
            /// <param name="func">执行的方法。</param>
            /// <returns>返回设置后的 <see cref="IOKBehavior&lt;T&gt;"/> 实例。</returns>
            IYesNoBehavior<T> OnYes(Func<T> func);
            /// <summary>
            /// 设置 Yes 按钮显示的文本内容。
            /// </summary>
            /// <param name="text">文本内容。</param>
            /// <returns>返回 <see cref="IOKBehavior&lt;T&gt;"/> 实例。</returns>
            IYesNoBehavior<T> SetYesText(string text);
                                    /// <summary>
            /// 指定当任意 <see cref="MessageBox"/>.Show 返回结果为 <see cref="DialogResult.No"/> 时，执行的方法。
            /// </summary>
            /// <param name="func">执行的方法。</param>
            /// <returns>返回设置后的 <see cref="IOKBehavior&lt;T&gt;"/> 实例。</returns>
            IYesNoBehavior<T> OnNo(Func<T> func);
            /// <summary>
            /// 设置 No 按钮显示的文本内容。
            /// </summary>
            /// <param name="text">文本内容。</param>
            /// <returns>返回 <see cref="IOKBehavior&lt;T&gt;"/> 实例。</returns>
            IYesNoBehavior<T> SetNoText(string text);
                                                                    }

          class YesNoBehavior: IYesNoBehavior
        {
            private readonly MessageBoxBehavior behavior;
            
                public YesNoBehavior(MessageBoxBehavior behavior){this.behavior=behavior;}
            
                                                    public  IYesNoBehavior OnYes(Action action)
                {
                    behavior.Add(DialogResult.Yes, action);
                    return this;
                }
                public IYesNoBehavior SetYesText(string text)
                {
                    behavior.AddText(DialogResult.Yes, text);
                    return this;
                }
                                        public  IYesNoBehavior OnNo(Action action)
                {
                    behavior.Add(DialogResult.No, action);
                    return this;
                }
                public IYesNoBehavior SetNoText(string text)
                {
                    behavior.AddText(DialogResult.No, text);
                    return this;
                }
                                                                            public void Show()
                { 
                    behavior.Invoke(MessageBoxButtons.YesNo, null);
                }
        }
        class YesNoBehavior<T>:IYesNoBehavior<T>
        { 
            private readonly MessageBoxBehavior behavior;
            public YesNoBehavior(MessageBoxBehavior behavior){this.behavior=behavior; }
                                                    public  IYesNoBehavior<T> OnYes(Func<T> func)
                {
                    behavior.Add(DialogResult.Yes, func);
                    return this;
                }
                public IYesNoBehavior<T> SetYesText(string text)
                {
                    behavior.AddText(DialogResult.Yes, text);
                    return this;
                }
                                        public  IYesNoBehavior<T> OnNo(Func<T> func)
                {
                    behavior.Add(DialogResult.No, func);
                    return this;
                }
                public IYesNoBehavior<T> SetNoText(string text)
                {
                    behavior.AddText(DialogResult.No, text);
                    return this;
                }
                                                                        public T Show()
            {
            return (T)behavior.Invoke(MessageBoxButtons.YesNo, default);
            }
        }
   
        /// <summary>
        /// 将此实例转换为包含 <see cref="MessageBoxButtons.RetryCancel"/> 操作的实例。
        /// </summary>
        /// <returns>返回 <see cref="IRetryCancelBehavior"/> 实例。</returns>
        public IRetryCancelBehavior AsRetryCancelBehavior()
        {
            return new RetryCancelBehavior(new MessageBoxBehavior(this));
        }

        /// <summary>
        /// 将此实例转换为包含 <see cref="MessageBoxButtons.RetryCancel"/> 操作的实例。
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <returns>返回 <see cref="IRetryCancelBehavior"/> 实例。</returns>
        public IRetryCancelBehavior<T> AsRetryCancelBehavior<T>()
        {
            return new RetryCancelBehavior<T>(new MessageBoxBehavior(this));
        }

        /// <summary>
        /// 定义一个包含 <see cref="MessageBoxButtons.RetryCancel"/> 按钮的操作。
        /// Implements the <see cref="MessageCollector.IMessageBoxBehavior" />
        /// </summary>
        /// <seealso cref="MessageCollector.IMessageBoxBehavior" />
        public interface IRetryCancelBehavior : IMessageBoxBehavior
        {
                                                                                    /// <summary>
            /// 指定当任意 <see cref="MessageBox"/>.Show 返回结果为 <see cref="DialogResult.Cancel"/> 时，执行的方法。
            /// </summary>
            /// <param name="Behavior">执行的方法。</param>
            /// <returns>返回设置后的 <see cref="IRetryCancelBehavior"/> 实例。</returns>
            IRetryCancelBehavior OnCancel(Action action);
            /// <summary>
            /// 设置 Cancel 按钮显示的文本内容。
            /// </summary>
            /// <param name="text">文本内容。</param>
            /// <returns>返回 <see cref="IOKBehavior"/> 实例。</returns>
            IRetryCancelBehavior SetCancelText(string text);
                                    /// <summary>
            /// 指定当任意 <see cref="MessageBox"/>.Show 返回结果为 <see cref="DialogResult.Retry"/> 时，执行的方法。
            /// </summary>
            /// <param name="Behavior">执行的方法。</param>
            /// <returns>返回设置后的 <see cref="IRetryCancelBehavior"/> 实例。</returns>
            IRetryCancelBehavior OnRetry(Action action);
            /// <summary>
            /// 设置 Retry 按钮显示的文本内容。
            /// </summary>
            /// <param name="text">文本内容。</param>
            /// <returns>返回 <see cref="IOKBehavior"/> 实例。</returns>
            IRetryCancelBehavior SetRetryText(string text);
                                }
        /// <summary>
        /// 定义一个包含 <see cref="MessageBoxButtons.RetryCancel"/> 按钮，且返回指定类型 <typeparamref name="T"/> 值的操作。
        /// Implements the <see cref="MessageCollector.IMessageBoxBehavior{T}" />
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <seealso cref="MessageCollector.IMessageBoxBehavior{T}" />
        public interface IRetryCancelBehavior<T>:IMessageBoxBehavior<T>
        { 
                                                                                    /// <summary>
            /// 指定当任意 <see cref="MessageBox"/>.Show 返回结果为 <see cref="DialogResult.Cancel"/> 时，执行的方法。
            /// </summary>
            /// <param name="func">执行的方法。</param>
            /// <returns>返回设置后的 <see cref="IOKBehavior&lt;T&gt;"/> 实例。</returns>
            IRetryCancelBehavior<T> OnCancel(Func<T> func);
            /// <summary>
            /// 设置 Cancel 按钮显示的文本内容。
            /// </summary>
            /// <param name="text">文本内容。</param>
            /// <returns>返回 <see cref="IOKBehavior&lt;T&gt;"/> 实例。</returns>
            IRetryCancelBehavior<T> SetCancelText(string text);
                                    /// <summary>
            /// 指定当任意 <see cref="MessageBox"/>.Show 返回结果为 <see cref="DialogResult.Retry"/> 时，执行的方法。
            /// </summary>
            /// <param name="func">执行的方法。</param>
            /// <returns>返回设置后的 <see cref="IOKBehavior&lt;T&gt;"/> 实例。</returns>
            IRetryCancelBehavior<T> OnRetry(Func<T> func);
            /// <summary>
            /// 设置 Retry 按钮显示的文本内容。
            /// </summary>
            /// <param name="text">文本内容。</param>
            /// <returns>返回 <see cref="IOKBehavior&lt;T&gt;"/> 实例。</returns>
            IRetryCancelBehavior<T> SetRetryText(string text);
                                }

          class RetryCancelBehavior: IRetryCancelBehavior
        {
            private readonly MessageBoxBehavior behavior;
            
                public RetryCancelBehavior(MessageBoxBehavior behavior){this.behavior=behavior;}
            
                                                                                        public  IRetryCancelBehavior OnCancel(Action action)
                {
                    behavior.Add(DialogResult.Cancel, action);
                    return this;
                }
                public IRetryCancelBehavior SetCancelText(string text)
                {
                    behavior.AddText(DialogResult.Cancel, text);
                    return this;
                }
                                        public  IRetryCancelBehavior OnRetry(Action action)
                {
                    behavior.Add(DialogResult.Retry, action);
                    return this;
                }
                public IRetryCancelBehavior SetRetryText(string text)
                {
                    behavior.AddText(DialogResult.Retry, text);
                    return this;
                }
                                        public void Show()
                { 
                    behavior.Invoke(MessageBoxButtons.RetryCancel, null);
                }
        }
        class RetryCancelBehavior<T>:IRetryCancelBehavior<T>
        { 
            private readonly MessageBoxBehavior behavior;
            public RetryCancelBehavior(MessageBoxBehavior behavior){this.behavior=behavior; }
                                                                                        public  IRetryCancelBehavior<T> OnCancel(Func<T> func)
                {
                    behavior.Add(DialogResult.Cancel, func);
                    return this;
                }
                public IRetryCancelBehavior<T> SetCancelText(string text)
                {
                    behavior.AddText(DialogResult.Cancel, text);
                    return this;
                }
                                        public  IRetryCancelBehavior<T> OnRetry(Func<T> func)
                {
                    behavior.Add(DialogResult.Retry, func);
                    return this;
                }
                public IRetryCancelBehavior<T> SetRetryText(string text)
                {
                    behavior.AddText(DialogResult.Retry, text);
                    return this;
                }
                                    public T Show()
            {
            return (T)behavior.Invoke(MessageBoxButtons.RetryCancel, default);
            }
        }
       }
}