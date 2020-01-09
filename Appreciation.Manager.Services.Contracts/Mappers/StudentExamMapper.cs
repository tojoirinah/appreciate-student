﻿using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using AutoMapper;
using System;

namespace Appreciation.Manager.Services.Contracts.Mappers
{
    public static class StudentExamMapper
    {
        public static void ProjectTo(this StudentExamRequest request, StudentExam entity)
        {
            entity.IsAbsent = request.IsAbsent;
            entity.IsClosed = request.IsClosed;
            entity.Note = request.Note;
            entity.BehaviorId = request.BehaviorId;
            entity.ExamId = request.ExamId;
        }


        public static StudentExam ProjectTo(this StudentExamRequest request, IMapper mapper)
        {
            StudentExam entity = mapper.Map<StudentExam>(request);
            entity.DateCreated = DateTime.Now;
            return entity;
        }
    }
}
