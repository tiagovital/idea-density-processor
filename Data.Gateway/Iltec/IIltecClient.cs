﻿namespace Data.Gateway
{
    using System.Threading.Tasks;

    public interface IIltecClient
    {
        Task<string> Search(string word);
    }
}