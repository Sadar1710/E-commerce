using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using Persistence;
using AutoMapper;

namespace Application.Products
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Product Product { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context,IMapper maper)
            {
                _context = context;
                _mapper = maper;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var product = await _context.Product.FindAsync(request.Product.Id);

                _mapper.Map(request.Product, product);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
