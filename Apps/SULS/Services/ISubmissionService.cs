﻿namespace SULS.Services
{
    public interface ISubmissionService
    {
        void Create(string problemId, string userId, string code);

        void Delete(string Id);
    }
}
