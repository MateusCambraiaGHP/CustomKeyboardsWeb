﻿using CustomKeyboardsWeb.Application.Features.Responses.Customers;
using CustomKeyboardsWeb.Core.Messages;

namespace CustomKeyboardsWeb.Application.Features.Queries.Customers
{
    public class GetCustumerByIdQuery : Query<GetCustomerByIdQueryResponse> 
    {
        public int IdCustomer { get; set; }

        public GetCustumerByIdQuery(int idCustomer) => IdCustomer = idCustomer;
    }
}
