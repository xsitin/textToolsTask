using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;

namespace DataAccess.models;

[Table("Words")]
[PrimaryKey(nameof(word))]
[Index(nameof(count), nameof(word))]
public class Word
{
    public Word(string word, int count)
    {
        this.word = word;
        this.count = count;
    }

    [MaxLength(20)]
    [MinLength(3)] 
    public string word { get; set; }
    public int count { get; set; }
}