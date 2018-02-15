﻿// <auto-generated />
using Dwapi.ExtractsManagement.Infrastructure;
using Dwapi.SharedKernel.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Dwapi.ExtractsManagement.Infrastructure.Migrations
{
    [DbContext(typeof(ExtractsContext))]
    partial class ExtractsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dwapi.ExtractsManagement.Core.Model.Extract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Display")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Extracts");
                });

            modelBuilder.Entity("Dwapi.ExtractsManagement.Core.Model.ExtractHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ExtractId");

                    b.Property<int?>("Stats");

                    b.Property<int>("Status");

                    b.Property<DateTime?>("StatusDate");

                    b.Property<string>("StatusInfo");

                    b.HasKey("Id");

                    b.HasIndex("ExtractId");

                    b.ToTable("ExtractHistories");
                });

            modelBuilder.Entity("Dwapi.ExtractsManagement.Core.Model.PsmartStage", b =>
                {
                    b.Property<Guid>("EId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateExtracted");

                    b.Property<DateTime?>("DateSent");

                    b.Property<DateTime>("DateStaged");

                    b.Property<DateTime?>("Date_Created");

                    b.Property<string>("Emr");

                    b.Property<int?>("Id");

                    b.Property<string>("RequestId");

                    b.Property<string>("Shr");

                    b.Property<string>("Status")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("Status_Date");

                    b.Property<string>("Uuid");

                    b.HasKey("EId");

                    b.ToTable("PsmartStages");
                });

            modelBuilder.Entity("Dwapi.ExtractsManagement.Core.Model.ExtractHistory", b =>
                {
                    b.HasOne("Dwapi.ExtractsManagement.Core.Model.Extract")
                        .WithMany("ExtractHistories")
                        .HasForeignKey("ExtractId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
