namespace YudianBlog.Model.Link
{
    /// <summary>
    /// 链接打开的方式，有三种，_blank为，_top为就，none为不选择，会。
    /// </summary>
    public enum LinkTarget
    {
        /// <summary>
        /// 以新窗口打开
        /// </summary>
        _blank=1,
        /// <summary>
        /// 清除所有被包含的框架并将文档载入整个浏览器窗口
        /// </summary>
        _top=2,
        /// <summary>
        /// 在本窗口中打开
        /// </summary>
        none=3
    }
}
