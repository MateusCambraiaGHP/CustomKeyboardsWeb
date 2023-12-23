using AutoMapper;
using CustomKeyboardsWeb.Application.Features.Queries.Keyboards;
using CustomKeyboardsWeb.Application.Features.Responses.Keyboards;
using CustomKeyboardsWeb.Application.Features.ViewModel.Keyboards;
using CustomKeyboardsWeb.Core.Messages.CommonMessages;
using CustomKeyboardsWeb.Data.Caching;
using CustomKeyboardsWeb.Domain.Primitives.Common.Interfaces.Repositories;
using CustomKeyboardsWeb.Domain.Primitives.Entities.Keyboards;
using FluentValidation.Results;
using System.Linq.Expressions;

namespace CustomKeyboardsWeb.Application.Features.QueryHandlers.Keyboards
{
    public class GetKeyBoardListHandle : Handler<GetKeyboardListQuery, GetKeyboardListQueryResponse>
    {
        private readonly IKeyboardRepository _keyboardRepository;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;

        public GetKeyBoardListHandle(
            IKeyboardRepository keyboardRepository,
            IMapper mapper,
            ICacheService cacheService)
            : base(mapper)
        {
            _keyboardRepository = keyboardRepository;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public override async Task<GetKeyboardListQueryResponse> Handle(GetKeyboardListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new Expression<Func<Keyboard, object>>[] { kb => kb.Key, kb => kb.Switch };
                var listKeyboard = await _keyboardRepository.GetAsync(null, null, includes);
                var listKeyboardMap = _mapper.Map<List<KeyboardViewModel>>(listKeyboard);
                foreach (var keyboard in listKeyboardMap)
                {
                    keyboard.Price += keyboard.Switch.Price.Value + keyboard.Key.Price.Value;
                }

                _cacheService.SetPost<KeyboardViewModel>(nameof(KeyboardViewModel), listKeyboardMap);
                return new GetKeyboardListQueryResponse(listKeyboardMap);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override List<ValidationFailure> Validate(GetKeyboardListQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
