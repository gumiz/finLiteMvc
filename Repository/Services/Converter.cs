using System.Collections.Generic;
using AutoMapper;

namespace Repository.Services
{
	public static class Converter
	{
		public static TModelOut Convert<TModelIn, TModelOut>(TModelIn data)
		{
			Mapper.CreateMap<TModelIn, TModelOut>();
			var result = Mapper.Map<TModelIn, TModelOut>(data);
			return result;
		}

		public static List<TModelOut> ConvertList<TModelIn, TModelOut>(List<TModelIn> data)
		{
			Mapper.CreateMap<TModelIn, TModelOut>();
			var result = Mapper.Map<List<TModelIn>, List<TModelOut>>(data);
			return result;
		}

	}
}