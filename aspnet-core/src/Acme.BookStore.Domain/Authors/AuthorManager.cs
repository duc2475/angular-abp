using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Acme.BookStore.Authors
{
    public class AuthorManager : DomainService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorManager(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> CreateAsync(string name, DateTime birthDate, string? shortBio)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            var existingAuthor = await _authorRepository.FindByNameAsync(name);
            if (existingAuthor != null) 
            {
                throw new AuthorAlreadyExistsException(name);
            }
            return new Author(
                GuidGenerator.Create(),
                name,
                birthDate,
                shortBio
                );
        }

        public async Task ChangeNameAsync(Author author,string newname)
        {
            Check.NotNull(author, nameof(author));
            Check.NotNullOrWhiteSpace(newname, nameof(newname));
            var existingAuthor = await _authorRepository.FindByNameAsync(newname);
            if(existingAuthor != null)
            {
                throw new AuthorAlreadyExistsException(newname);
            }
            author.ChangeName(newname);
        }
    }
}
