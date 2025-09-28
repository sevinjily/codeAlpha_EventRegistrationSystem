namespace EventRegistration.Application.Interfaces.AutoMapper
{
    public interface IMapper
    {
        TDestination Map<TDestination,TSource>(TSource source,string? ignore=null);

        IList<TDestination> Map<TDestination,TSource>(IList<TSource> source,string? ignore=null);

        TDestination Map<TDestination>(object source, string? ignore = null);

        IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null);



        //TDestination-neye cevirmek isteyirik(meselen dto-a)
        //TSource-neyi cevirmek isteyirik(meselen her hansi entity)
        //string? ignore=null -bezi fieldleri ignore etmek isteye bilerik.Optional olaraq yaziriq, elave
        //IList<object> source yazib TSource u silme sebebimiz 9 ve 11ci setirde,ferqli tipde nese qaytarmaq isteye bilerik
    }
}
