using Models.ImageModels;

namespace Services.Repository.ImageRepository;

public interface IImageService : IRepository<ImageBase,ImageDto,ImageCreate> { }