using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YudianBlog.Infrastructure.Querying
{
    /// <summary>
    /// 有时候复杂的查询对象难以构建，我们会通过存储过程或视图来处理此种情况，需要构建一个枚举QueryName用来指示是存储过程(视图)还是构建动态的sql语句
    /// </summary>
    public enum QueryName
    {
        Dynamic = 0, //动态创建
        RetrieveOrdersUsingAComplexQuery = 1//使用已经创建好了的存储过程、视图、特别是查询比较复杂时使用存储过程
    }
}
