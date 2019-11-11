using System.Collections.Generic;
using System.ComponentModel;

namespace System.Windows.Forms
{
    /// <summary>
    /// Defines the <see cref="MessageBoxArguments" />
    /// </summary>
    public partial class MessageBoxArguments
    {
        private readonly string text;

        private readonly string title;

        private MessageBoxDefaultButton defaultButton = default;

        private string helpFilePath;

        private MessageBoxIcon icon;

        private string keyword;

        private HelpNavigator navigator = default;

        private MessageBoxOptions options = default;

        private IWin32Window owner = default;

        private object param;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxArguments"/> class.
        /// </summary>
        /// <param name="text">The text<see cref="string"/></param>
        /// <param name="title">The title<see cref="string"/></param>
        /// <param name="icon">The icon<see cref="MessageBoxIcon"/></param>
        public MessageBoxArguments(string text, string title, MessageBoxIcon icon)
        {
            this.text = text;
            this.title = title;
            this.icon = icon;
        }

        /// <summary>
        /// 定义 <see cref="MessageBox"/> 执行行为。
        /// </summary>
        public interface IMessageBoxBehavior
        {
            /// <summary>
            /// 显示 <see cref="MessageBox"/> 文本内容提示框。
            /// </summary>
            void Show();
        }

        /// <summary>
        /// 定义 <see cref="MessageBox"/> 执行行为。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public interface IMessageBoxBehavior<T>
        {
            /// <summary>
            /// 显示 <see cref="MessageBox"/> 文本内容提示框。
            /// </summary>
            /// <returns>返回 <see cref="T"/> 实例。</returns>
            T Show();
        }

        /// <summary>
        /// 指定若干常数，用以定义 System.Windows.Forms.MessageBox 上的默认按钮。
        /// </summary>
        /// <param name="defaultButton">MessageBoxDefaultButton 值之一，可指定消息框中的默认按钮。</param>
        /// <returns>返回 <see cref="MessageBoxArguments"/> 实例。</returns>
        public MessageBoxArguments DefaultButton(MessageBoxDefaultButton defaultButton)
        {
            this.defaultButton = defaultButton;
            return this;
        }

        /// <summary>
        /// 指定 <see cref="MessageBox"/> 使用指定的帮助文件、 <see cref="HelpNavigator"/> 和帮助主题。
        /// </summary>
        /// <param name="helpFilePath">用户单击“帮助”按钮时显示的“帮助”文件的路径和名称。</param>
        /// <param name="navigator">HelpNavigator 值之一。</param>
        /// <param name="param">用户单击“帮助”按钮时显示的帮助主题的数值 ID。</param>
        /// <returns>返回 <see cref="MessageBoxArguments"/> 实例。</returns>
        public MessageBoxArguments Help(string helpFilePath, HelpNavigator navigator, object param = default)
        {
            this.helpFilePath = helpFilePath;
            this.navigator = navigator;
            this.param = param;
            return this;
        }

        /// <summary>
        /// 指定 <see cref="MessageBox"/> 使用指定的帮助文件和帮助关键字
        /// </summary>
        /// <param name="helpFilePath">用户单击“帮助”按钮时显示的“帮助”文件的路径和名称。</param>
        /// <param name="keyword">在用户单击“帮助”按钮时显示的帮助关键字。</param>
        /// <returns>返回 <see cref="MessageBoxArguments"/> 实例。</returns>
        public MessageBoxArguments Help(string helpFilePath, string keyword = default)
        {
            this.helpFilePath = helpFilePath;
            navigator = default;
            this.keyword = keyword;
            return this;
        }

        /// <summary>
        /// 指定 <see cref="MessageBox"/> 上的选项。
        /// </summary>
        /// <param name="options">MessageBoxOptions 值之一，可指定将对消息框使用哪些显示和关联选项。 若要使用默认值，请传入 0。</param>
        /// <returns>返回 <see cref="MessageBoxArguments"/> 实例。</returns>
        public MessageBoxArguments Options(MessageBoxOptions options)
        {

            this.options = options;
            return this;
        }
        /// <summary>
        /// 指定拥有模式对话框的 IWin32Window 的一个实现
        /// </summary>
        /// <param name="owner">将拥有模式对话框的 IWin32Window 的一个实现。</param>
        /// <returns>返回 <see cref="MessageBoxArguments"/> 实例。</returns>
        public MessageBoxArguments Owner(IWin32Window owner)
        {
            this.owner = owner;
            return this;
        }

        class MessageBoxBehavior
        {
            private readonly MessageBoxArguments arguments;

            Dictionary<DialogResult, Delegate> delegates = new Dictionary<DialogResult, Delegate>();
            Dictionary<DialogResult, string> texts = new Dictionary<DialogResult, string>();

            public MessageBoxBehavior(MessageBoxArguments arguments)
            {
                this.arguments = arguments;
            }

            public void Add(DialogResult result, Delegate @delegate)
            {
                delegates[result] = @delegate;
            }
            public void AddText(DialogResult result, string text)
            {
                texts[result] = text;
            }

            public object Invoke(MessageBoxButtons buttons, object defaultResult)
            {
                var result = ShowMessageBox(buttons);
                if (delegates.ContainsKey(result))
                {
                    return delegates[result].DynamicInvoke();
                }
                else
                {
                    return defaultResult;
                }
            }

            private DialogResult ShowDialog(MessageBoxButtons buttons)
            {
                if (!Application.RenderWithVisualStyles)
                {
                    Application.VisualStyleState = VisualStyles.VisualStyleState.ClientAndNonClientAreasEnabled;
                    Application.EnableVisualStyles();
                }
                if (texts.Count > 0)
                {
                    var hook = new CodeProject.Win32API.Hook.CbtHook();
                    hook.Install();
                    hook.WindowActivate += Hook_WindowActivate;
                }
                if (string.IsNullOrEmpty(arguments.helpFilePath))
                {
                    return MessageBox.Show(arguments.owner,
                        arguments.text,
                        arguments.title,
                        buttons,
                        arguments.icon,
                        arguments.defaultButton,
                        arguments.options);
                }
                else
                {
                    if (arguments.navigator == default)
                    {
                        if (arguments.keyword == default)
                        {
                            return MessageBox.Show(arguments.owner,
                                arguments.text,
                                arguments.title,
                                buttons,
                                arguments.icon,
                                arguments.defaultButton,
                                arguments.options,
                                arguments.helpFilePath);
                        }
                        else
                        {
                            return MessageBox.Show(arguments.owner,
                                arguments.text,
                                arguments.title,
                                buttons,
                                arguments.icon,
                                arguments.defaultButton,
                                arguments.options,
                                arguments.helpFilePath,
                                arguments.keyword);
                        }
                    }
                    else
                    {
                        if (arguments.param == null)
                        {
                            return MessageBox.Show(arguments.owner,
                            arguments.text,
                            arguments.title,
                            buttons,
                            arguments.icon,
                            arguments.defaultButton,
                            arguments.options,
                            arguments.helpFilePath,
                            arguments.navigator);
                        }
                        else
                        {
                            return MessageBox.Show(arguments.owner,
                            arguments.text,
                            arguments.title,
                            buttons,
                            arguments.icon,
                            arguments.defaultButton,
                            arguments.options,
                            arguments.helpFilePath,
                            arguments.navigator,
                            arguments.param);
                        }
                    }
                }
            }

            private void Hook_WindowActivate(object sender, CodeProject.Win32API.Hook.CbtEventArgs e)
            {
                foreach (var text in texts)
                {
                    CodeProject.Win32API.USER32.SetDlgItemText(e.wParam, (int)text.Key, text.Value);
                }
                (sender as CodeProject.Win32API.Hook.CbtHook).WindowActivate -= Hook_WindowActivate;
                (sender as CodeProject.Win32API.Hook.CbtHook).Uninstall();
            }

            private DialogResult ShowMessageBox(MessageBoxButtons buttons)
            {
                if (arguments.owner is ISynchronizeInvoke synchronizeInvoke && synchronizeInvoke.InvokeRequired)
                {
                    return (DialogResult)synchronizeInvoke.Invoke(new MethodInvoker(() => ShowDialog(buttons)), null);
                }
                else
                {
                    return ShowDialog(buttons);
                }
            }
        }
    }
}
