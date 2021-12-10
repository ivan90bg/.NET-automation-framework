using Newtonsoft.Json;
namespace Everstox.Infrastructure
{
   public class RequestDeserializer
   {
      public static T? Deserialize<T>(string content)
      {
         return JsonConvert.DeserializeObject<T>(File.ReadAllText(content));
      }
   }
}
