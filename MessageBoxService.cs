namespace System.Windows.Forms
{
    using System.Threading.Tasks;
    using static MessageBoxArguments;
    /// <summary>
    /// 提供消息框拓展服务。
    /// </summary>
    public static partial class MessageBoxService
    {
        /// <summary>
        /// 使用异步方式显示 <see cref="MessageBox"/> 文本内容提示框，并返回此操作的 <see cref="Task"/>。
        /// </summary>
        /// <param name="behavior">The behavior.</param>
        /// <returns>返回 <see cref="Task"/> 实例。</returns>
        public static async Task ShowAsync(this IMessageBoxBehavior behavior)
        {
            await Task.Run(() => behavior.Show()).ConfigureAwait(false);
        }

        /// <summary>
        /// 使用异步方式显示 <see cref="MessageBox"/> 文本内容提示框，并返回此操作的 <see cref="Task{TResult}"/>。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="behavior">The behavior.</param>
        /// <returns>返回 <see cref="Task&lt;T&gt;"/> 实例。</returns>
        public static async Task<T> ShowAsync<T>(this IMessageBoxBehavior<T> behavior)
        {
            return await Task.Run(() => behavior.Show()).ConfigureAwait(false);
        }
    }
}
