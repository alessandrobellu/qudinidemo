using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Data;

namespace QudiniDemo.Converters
{
	public class MailToImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			string mail = value as string;
			if (String.IsNullOrEmpty(mail)) return null;

			mail = mail.ToLower().Trim();
			var md5 = ComputeMD5(mail);

			return String.Format("http://www.gravatar.com/avatar/{0}?s=200&d=404", md5);
		}

		public static string ComputeMD5(string str)
		{
			var alg = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);
			IBuffer buff = CryptographicBuffer.ConvertStringToBinary(str, BinaryStringEncoding.Utf8);
			var hashed = alg.HashData(buff);
			var res = CryptographicBuffer.EncodeToHexString(hashed);
			return res;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
