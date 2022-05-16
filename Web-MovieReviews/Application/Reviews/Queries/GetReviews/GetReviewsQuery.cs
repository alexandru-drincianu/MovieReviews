﻿using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reviews.Queries.GetReviews
{
    public class GetReviewsQuery : IRequest<IEnumerable<Review>>
    {
    }
}
