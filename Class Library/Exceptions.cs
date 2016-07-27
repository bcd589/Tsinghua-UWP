﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsinghuaUWP
{
    public class UserCancelException : Exception
    {
    }


    public class NeedCampusNetworkException : Exception
    {
    }

    public class LoginException : Exception
    {
        public new string Message;
        public LoginException(string _msg)
        {
            Message = _msg;
        }
    }

    public class ParsePageException : Exception
    {
        string additionalInfo;
        public ParsePageException(string _ = "")
        {
            additionalInfo = _;
        }
        public string verbose()
        {
            return $@"
服务器返回数据解析错误

{this.additionalInfo} ({Exceptions.getFriendlyMessage(this)})

如果此类错误重复出现，十有八九是学校那边改了接口。
请与作者联系并等待更新。";
        }
    }

    public class Exceptions
    {
        public static string getFriendlyMessage(Exception e)
        {
            return e.Message
                .Replace("无法找到与此错误代码关联的文本。", "")
                .Replace("The text associated with this error code could not be found.", "")
                .Trim();
        }
    }
}
