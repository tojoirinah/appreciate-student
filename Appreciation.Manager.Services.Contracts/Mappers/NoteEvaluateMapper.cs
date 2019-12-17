using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using AutoMapper;
using System;

namespace Appreciation.Manager.Services.Contracts.Mappers
{
    public static class NoteEvaluateMapper
    {
        public static void ProjectTo(this UpdateNoteEvaluateRequest request, NoteEvaluate entity)
        {
            entity.NoteCriteriaId = request.NoteCriteriaId;
            entity.Evaluation = request.Evaluation;
            entity.Advice = request.Advice;
        }

        public static NoteEvaluate ProjectTo(this AddNoteEvaluateRequest request, IMapper mapper)
        {
            NoteEvaluate item = mapper.Map<NoteEvaluate>(request);
            item.DateCreated = DateTime.Now;
            return item;
        }
    }
}
