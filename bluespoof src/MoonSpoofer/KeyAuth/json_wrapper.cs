using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace KeyAuth
{
	// Token: 0x0200000E RID: 14
	public class json_wrapper
	{
		// Token: 0x06000083 RID: 131 RVA: 0x00002387 File Offset: 0x00000587
		public static bool is_serializable(Type to_check)
		{
			return to_check.IsSerializable || to_check.IsDefined(typeof(DataContractAttribute), true);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00003EEC File Offset: 0x000020EC
		public json_wrapper(object obj_to_work_with)
		{
			this.current_object = obj_to_work_with;
			Type type = this.current_object.GetType();
			this.serializer = new DataContractJsonSerializer(type);
			bool flag = !json_wrapper.is_serializable(type);
			if (flag)
			{
				throw new Exception(string.Format("the object {0} isn't a serializable", this.current_object));
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00003F44 File Offset: 0x00002144
		public object string_to_object(string json)
		{
			byte[] bytes = Encoding.Default.GetBytes(json);
			object result;
			using (MemoryStream memoryStream = new MemoryStream(bytes))
			{
				result = this.serializer.ReadObject(memoryStream);
			}
			return result;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x000023A5 File Offset: 0x000005A5
		public T string_to_generic<T>(string json)
		{
			return (T)((object)this.string_to_object(json));
		}

		// Token: 0x04000038 RID: 56
		private DataContractJsonSerializer serializer;

		// Token: 0x04000039 RID: 57
		private object current_object;
	}
}
