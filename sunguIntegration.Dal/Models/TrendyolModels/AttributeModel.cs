using System;
using Newtonsoft.Json;

namespace sunguIntegration.Dal.Models
{
	public class AttributeModel
	{
        public int id { get; set; }
        public long attributeId { get; set; }
        public long? attributeValueId { get; set; }
        public string customAttributeValue { get; set; }

    }
}

