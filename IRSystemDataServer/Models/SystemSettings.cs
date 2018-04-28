using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace IRSystemDataServer.Models
{
    public sealed class SystemSettings: ConfigurationSection
    {
        [ConfigurationProperty("CameraConfigBaseUrl", IsRequired = true)]
        public string CameraConfigBaseUrl
        {
            get { return (string)base["CameraConfigBaseUrl"]; }
            set { base["CameraConfigBaseUrl"] = value; }
        }

        [ConfigurationProperty("IrImageDataBaseDir", IsRequired = true)]
        public string IrImageDataBaseDir
        {
            get { return (string)base["IrImageDataBaseDir"]; }
            set { base["IrImageDataBaseDir"] = value; }
        }

        [ConfigurationProperty("IrImageDataBaseUri", IsRequired = true)]
        public string IrImageDataBaseUri
        {
            get { return (string)base["IrImageDataBaseUri"]; }
            set { base["IrImageDataBaseUri"] = value; }
        }

        //一个元素  
        [ConfigurationProperty("AliyunSettings", IsRequired = true)]
        public AliyunSettings AppElement
        {
            get { return (AliyunSettings)base["AliyunSettings"]; }
        }
    }


    public sealed class AliyunSettings : ConfigurationElement
    {
        //这是定义基本的元素类，它有三个属性，默认第一属性为它的Key，Key的值不能重复  
        [ConfigurationProperty("OSS", IsRequired = true)]
        public string KeyName
        {
            get { return this["KeyName"].ToString(); }
            set { base["KeyName"] = value; }
        }

        [ConfigurationProperty("KeyValue", IsRequired = false)]
        public string KeyValue
        {
            get { return this["KeyValue"].ToString(); }
            set { this["KeyValue"] = value; }
        }

        [ConfigurationProperty("KeyValue2", IsRequired = false)]
        public string KeyValue2
        {
            get { return this["KeyValue2"].ToString(); }
            set { this["KeyValue2"] = value; }
        }
    }
}