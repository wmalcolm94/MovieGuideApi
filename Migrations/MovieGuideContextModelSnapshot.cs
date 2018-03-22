﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MovieGuideApi.Models;
using System;

namespace MovieGuideApi.Migrations
{
    [DbContext(typeof(MovieGuideContext))]
    partial class MovieGuideContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MovieGuideApi.Models.Chat", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Userid");

                    b.HasKey("id");

                    b.HasIndex("Userid");

                    b.ToTable("Chat");
                });

            modelBuilder.Entity("MovieGuideApi.Models.Message", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("chatId");

                    b.Property<string>("message");

                    b.Property<DateTime>("sent");

                    b.Property<int>("userId");

                    b.HasKey("id");

                    b.HasIndex("chatId");

                    b.HasIndex("userId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("MovieGuideApi.Models.Movie", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("chatId");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.HasIndex("chatId");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("MovieGuideApi.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("email");

                    b.Property<string>("name");

                    b.Property<string>("password");

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MovieGuideApi.Models.Chat", b =>
                {
                    b.HasOne("MovieGuideApi.Models.User")
                        .WithMany("chats")
                        .HasForeignKey("Userid");
                });

            modelBuilder.Entity("MovieGuideApi.Models.Message", b =>
                {
                    b.HasOne("MovieGuideApi.Models.Chat", "chat")
                        .WithMany("messages")
                        .HasForeignKey("chatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MovieGuideApi.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MovieGuideApi.Models.Movie", b =>
                {
                    b.HasOne("MovieGuideApi.Models.Chat", "chat")
                        .WithMany()
                        .HasForeignKey("chatId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
