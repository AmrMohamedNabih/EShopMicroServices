

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommend(string Name ,List<string> Categoury , string Description , string ImageFile , decimal Price ) : ICommend<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommendHandler(IDocumentSession session) : ICommendHandler<CreateProductCommend, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommend request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Category = request.Categoury,
                Description = request.Description,
                ImageFile = request.ImageFile,
                Price = request.Price,

            };
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            return new CreateProductResult(product.Id);
        }
    }
}
