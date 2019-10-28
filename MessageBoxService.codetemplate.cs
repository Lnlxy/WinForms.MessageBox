using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System.Windows.Forms
{
    partial class MessageBoxService
    {
    

        /// <summary>
        ///  Create a <see cref="MessageBoxArguments"/> with <see cref="MessageBoxIcon.None"/>.
        /// </summary>
        /// <param name="text">显示的文本信息。</param>
        /// <returns>返回 <see cref="MessageBoxArguments"/> 实例。</returns>
        public static MessageBoxArguments None(string text) => new MessageBoxArguments(text, string.Empty, MessageBoxIcon.None);
    
        /// <summary>
        ///  Create a <see cref="MessageBoxArguments"/> with <see cref="MessageBoxIcon.None"/>.
        /// </summary>
        /// <param name="text">显示的文本信息。</param>
        /// <param name="title">显示的标题信息。</param>
        /// <returns>返回 <see cref="MessageBoxArguments"/> 实例。</returns>
        public static MessageBoxArguments None(string text, string title) => new MessageBoxArguments(text, title, MessageBoxIcon.None);    

        /// <summary>
        ///  Create a <see cref="MessageBoxArguments"/> with <see cref="MessageBoxIcon.Hand"/>.
        /// </summary>
        /// <param name="text">显示的文本信息。</param>
        /// <returns>返回 <see cref="MessageBoxArguments"/> 实例。</returns>
        public static MessageBoxArguments Hand(string text) => new MessageBoxArguments(text, string.Empty, MessageBoxIcon.Hand);
    
        /// <summary>
        ///  Create a <see cref="MessageBoxArguments"/> with <see cref="MessageBoxIcon.Hand"/>.
        /// </summary>
        /// <param name="text">显示的文本信息。</param>
        /// <param name="title">显示的标题信息。</param>
        /// <returns>返回 <see cref="MessageBoxArguments"/> 实例。</returns>
        public static MessageBoxArguments Hand(string text, string title) => new MessageBoxArguments(text, title, MessageBoxIcon.Hand);    

        /// <summary>
        ///  Create a <see cref="MessageBoxArguments"/> with <see cref="MessageBoxIcon.Error"/>.
        /// </summary>
        /// <param name="text">显示的文本信息。</param>
        /// <returns>返回 <see cref="MessageBoxArguments"/> 实例。</returns>
        public static MessageBoxArguments Error(string text) => new MessageBoxArguments(text, string.Empty, MessageBoxIcon.Error);
    
        /// <summary>
        ///  Create a <see cref="MessageBoxArguments"/> with <see cref="MessageBoxIcon.Error"/>.
        /// </summary>
        /// <param name="text">显示的文本信息。</param>
        /// <param name="title">显示的标题信息。</param>
        /// <returns>返回 <see cref="MessageBoxArguments"/> 实例。</returns>
        public static MessageBoxArguments Error(string text, string title) => new MessageBoxArguments(text, title, MessageBoxIcon.Error);    

        /// <summary>
        ///  Create a <see cref="MessageBoxArguments"/> with <see cref="MessageBoxIcon.Stop"/>.
        /// </summary>
        /// <param name="text">显示的文本信息。</param>
        /// <returns>返回 <see cref="MessageBoxArguments"/> 实例。</returns>
        public static MessageBoxArguments Stop(string text) => new MessageBoxArguments(text, string.Empty, MessageBoxIcon.Stop);
    
        /// <summary>
        ///  Create a <see cref="MessageBoxArguments"/> with <see cref="MessageBoxIcon.Stop"/>.
        /// </summary>
        /// <param name="text">显示的文本信息。</param>
        /// <param name="title">显示的标题信息。</param>
        /// <returns>返回 <see cref="MessageBoxArguments"/> 实例。</returns>
        public static MessageBoxArguments Stop(string text, string title) => new MessageBoxArguments(text, title, MessageBoxIcon.Stop);    

        /// <summary>
        ///  Create a <see cref="MessageBoxArguments"/> with <see cref="MessageBoxIcon.Question"/>.
        /// </summary>
        /// <param name="text">显示的文本信息。</param>
        /// <returns>返回 <see cref="MessageBoxArguments"/> 实例。</returns>
        public static MessageBoxArguments Question(string text) => new MessageBoxArguments(text, string.Empty, MessageBoxIcon.Question);
    
        /// <summary>
        ///  Create a <see cref="MessageBoxArguments"/> with <see cref="MessageBoxIcon.Question"/>.
        /// </summary>
        /// <param name="text">显示的文本信息。</param>
        /// <param name="title">显示的标题信息。</param>
        /// <returns>返回 <see cref="MessageBoxArguments"/> 实例。</returns>
        public static MessageBoxArguments Question(string text, string title) => new MessageBoxArguments(text, title, MessageBoxIcon.Question);    

        /// <summary>
        ///  Create a <see cref="MessageBoxArguments"/> with <see cref="MessageBoxIcon.Exclamation"/>.
        /// </summary>
        /// <param name="text">显示的文本信息。</param>
        /// <returns>返回 <see cref="MessageBoxArguments"/> 实例。</returns>
        public static MessageBoxArguments Exclamation(string text) => new MessageBoxArguments(text, string.Empty, MessageBoxIcon.Exclamation);
    
        /// <summary>
        ///  Create a <see cref="MessageBoxArguments"/> with <see cref="MessageBoxIcon.Exclamation"/>.
        /// </summary>
        /// <param name="text">显示的文本信息。</param>
        /// <param name="title">显示的标题信息。</param>
        /// <returns>返回 <see cref="MessageBoxArguments"/> 实例。</returns>
        public static MessageBoxArguments Exclamation(string text, string title) => new MessageBoxArguments(text, title, MessageBoxIcon.Exclamation);    

        /// <summary>
        ///  Create a <see cref="MessageBoxArguments"/> with <see cref="MessageBoxIcon.Warning"/>.
        /// </summary>
        /// <param name="text">显示的文本信息。</param>
        /// <returns>返回 <see cref="MessageBoxArguments"/> 实例。</returns>
        public static MessageBoxArguments Warning(string text) => new MessageBoxArguments(text, string.Empty, MessageBoxIcon.Warning);
    
        /// <summary>
        ///  Create a <see cref="MessageBoxArguments"/> with <see cref="MessageBoxIcon.Warning"/>.
        /// </summary>
        /// <param name="text">显示的文本信息。</param>
        /// <param name="title">显示的标题信息。</param>
        /// <returns>返回 <see cref="MessageBoxArguments"/> 实例。</returns>
        public static MessageBoxArguments Warning(string text, string title) => new MessageBoxArguments(text, title, MessageBoxIcon.Warning);    

        /// <summary>
        ///  Create a <see cref="MessageBoxArguments"/> with <see cref="MessageBoxIcon.Asterisk"/>.
        /// </summary>
        /// <param name="text">显示的文本信息。</param>
        /// <returns>返回 <see cref="MessageBoxArguments"/> 实例。</returns>
        public static MessageBoxArguments Asterisk(string text) => new MessageBoxArguments(text, string.Empty, MessageBoxIcon.Asterisk);
    
        /// <summary>
        ///  Create a <see cref="MessageBoxArguments"/> with <see cref="MessageBoxIcon.Asterisk"/>.
        /// </summary>
        /// <param name="text">显示的文本信息。</param>
        /// <param name="title">显示的标题信息。</param>
        /// <returns>返回 <see cref="MessageBoxArguments"/> 实例。</returns>
        public static MessageBoxArguments Asterisk(string text, string title) => new MessageBoxArguments(text, title, MessageBoxIcon.Asterisk);    

        /// <summary>
        ///  Create a <see cref="MessageBoxArguments"/> with <see cref="MessageBoxIcon.Information"/>.
        /// </summary>
        /// <param name="text">显示的文本信息。</param>
        /// <returns>返回 <see cref="MessageBoxArguments"/> 实例。</returns>
        public static MessageBoxArguments Information(string text) => new MessageBoxArguments(text, string.Empty, MessageBoxIcon.Information);
    
        /// <summary>
        ///  Create a <see cref="MessageBoxArguments"/> with <see cref="MessageBoxIcon.Information"/>.
        /// </summary>
        /// <param name="text">显示的文本信息。</param>
        /// <param name="title">显示的标题信息。</param>
        /// <returns>返回 <see cref="MessageBoxArguments"/> 实例。</returns>
        public static MessageBoxArguments Information(string text, string title) => new MessageBoxArguments(text, title, MessageBoxIcon.Information);    }
}