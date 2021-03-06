using AutoMapper;
using Data;
using Models.ImageModels;

namespace Services.Repository.ImageRepository;

public class ImageService : Repository<ImageBase,ImageDto,ImageCreate,ImageUpdate> , IImageService
{
    public ImageService(ApplicationDbContext db, IMapper mapper) : base(db, mapper) { }
}