﻿using Microsoft.EntityFrameworkCore;
using quiz_v2.Data;
using quiz_v2.Models;

namespace quiz_v2.Screens.CategoryScreens;

internal class CreateCategoryScreen
{
    internal static void Load()
    {
        Console.WriteLine("-----CRIAÇÃO DE CATEGORIA-----");
        Console.WriteLine("(1) - Criar categoria");
        Console.WriteLine("(0) - Voltar");
        var option = int.Parse(Console.ReadLine());
        if (option == 0)
            MenuCategoryScreen.Load();
        Console.Clear();
        Console.WriteLine("Nova categoria");
        Console.WriteLine("-------------");
        Console.Write("Nome: ");
        var matter = Console.ReadLine();
        Create(matter);
    }
    private static void Create(string matter)
    {
        using var context = new QuizDataContext();
        CheckDuplicity(context, matter);
        try
        {
            context.Categories
                .Add(new Category
                {
                    Name = matter,
                    Slug = matter.ToLower()
                });
            context.SaveChanges();
            Console.WriteLine("Categoria cadastrada com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para retornar ao menu.");
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível salvar a categoria");
            Console.WriteLine(ex.Message);
        }
    }
    private static void CheckDuplicity(QuizDataContext context, string matter)
    {
        var categories = context.Categories
                        .AsNoTracking()
                        .ToList();
        foreach (var category in categories)
        {
            if (category == null || category.Name == matter)
            {
                Console.WriteLine("Não foi possível efetuar o cadastrar, matéria já cadastrada.");
                Console.WriteLine("Presione qualquer tecla para tentar novamente.");
                Console.ReadKey();
                Load();
            }
        }
    }
}