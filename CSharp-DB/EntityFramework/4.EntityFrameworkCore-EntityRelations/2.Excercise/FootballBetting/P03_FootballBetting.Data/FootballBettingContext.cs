﻿using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;
using System;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(x => x.TeamId);

                entity.Property(x => x.Name)
                      .IsUnicode(true)
                      .HasMaxLength(50)
                      .IsRequired(true);

                entity.Property(x => x.LogoUrl)
                      .IsUnicode(false)
                      .IsRequired(true);

                entity.Property(x => x.Initials)
                      .IsUnicode(true)
                      .HasMaxLength(3)
                      .IsRequired(true);

                entity.HasOne(x => x.PrimaryKitColor)
                      .WithMany(x => x.PrimaryKitTeams)
                      .HasForeignKey(x => x.PrimaryKitColorId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.SecondaryKitColor)
                      .WithMany(x => x.SecondaryKitTeams)
                      .HasForeignKey(x => x.SecondaryKitColorId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Town)
                      .WithMany(x => x.Teams)
                      .HasForeignKey(x => x.TownId);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(x => x.ColorId);

                entity.Property(x => x.Name)
                      .IsUnicode(false)
                      .HasMaxLength(30)
                      .IsRequired(true);
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity.HasKey(x => x.TownId);

                entity.Property(x => x.Name)
                      .IsUnicode(true)
                      .HasMaxLength(50)
                      .IsRequired(true);

                entity.HasOne(x => x.Country)
                      .WithMany(x => x.Towns)
                      .HasForeignKey(x => x.CountryId);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(x => x.CountryId);

                entity.Property(x => x.Name)
                      .IsUnicode(false)
                      .HasMaxLength(50)
                      .IsRequired(true);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(x => x.PlayerId);

                entity.Property(x => x.Name)
                      .IsUnicode(true)
                      .HasMaxLength(50)
                      .IsRequired(true);

                entity.HasOne(x => x.Team)
                      .WithMany(x => x.Players)
                      .HasForeignKey(x => x.TeamId);

                entity.HasOne(x => x.Position)
                     .WithMany(x => x.Players)
                     .HasForeignKey(x => x.PositionId);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(x => x.PositionId);

                entity.Property(x => x.Name)
                      .IsUnicode(false)
                      .HasMaxLength(30)
                      .IsRequired(true);
            });

            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(x => new { x.PlayerId, x.GameId});

                entity.HasOne(x => x.Player)
                      .WithMany(x => x.PlayerStatistics)
                      .HasForeignKey(x => x.PlayerId);

                entity.HasOne(x => x.Game)
                     .WithMany(x => x.PlayerStatistics)
                     .HasForeignKey(x => x.GameId);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(x => x.GameId);

                entity.Property(x => x.Result)
                      .IsUnicode(false)
                      .HasMaxLength(7)
                      .IsRequired(false);

                entity.HasOne(x => x.HomeTeam)
                      .WithMany(x => x.HomeGames)
                      .HasForeignKey(x => x.HomeTeamId)
                      .OnDelete(DeleteBehavior.Restrict); 

                entity.HasOne(x => x.AwayTeam)
                     .WithMany(x => x.AwayGames)
                     .HasForeignKey(x => x.AwayTeamId)
                     .OnDelete(DeleteBehavior.Restrict); 
            });

            modelBuilder.Entity<Bet>(entity =>
            {
                entity.HasKey(x => x.Betid);

                entity.HasOne(x => x.User)
                      .WithMany(x => x.Bets)
                      .HasForeignKey(x => x.UserId);

                entity.HasOne(x => x.Game)
                      .WithMany(x => x.Bets)
                      .HasForeignKey(x => x.GameId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.UserId);

                entity.Property(x => x.Username)
                      .IsUnicode(false)
                      .HasMaxLength(50)
                      .IsRequired(true);

                entity.Property(x => x.Password)
                      .IsUnicode(false)
                      .HasMaxLength(256)
                      .IsRequired(true);

                entity.Property(x => x.Email)
                      .IsUnicode(false)
                      .HasMaxLength(256)
                      .IsRequired(true);

                entity.Property(x => x.Name)
                      .IsUnicode(true)
                      .HasMaxLength(80)
                      .IsRequired(false);
            });
        }
    }
}
