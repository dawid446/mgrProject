using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Domain.Entity
{
    public partial class shopContext : DbContext
    {
        public shopContext()
        {
        }

        public shopContext(DbContextOptions<shopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ShipmentAdress> ShipmentAdresses { get; set; }
        public virtual DbSet<ShipmentDetail> ShipmentDetails { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.IdCart)
                    .HasName("PRIMARY");

                entity.ToTable("cart");

                entity.HasIndex(e => e.IdUserFk, "fk_cart_user1_idx");

                entity.Property(e => e.IdCart)
                    .ValueGeneratedNever()
                    .HasColumnName("id_cart");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.IdUserFk).HasColumnName("id_user_fk");

                entity.Property(e => e.SessionId)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("session_id");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("token");

                entity.HasOne(d => d.IdUserFkNavigation)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.IdUserFk)
                    .HasConstraintName("fk_cart_user");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("PRIMARY");

                entity.ToTable("category");

                entity.Property(e => e.IdCategory)
                    .ValueGeneratedNever()
                    .HasColumnName("id_category");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(45)
                    .HasColumnName("category_name");

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => new { e.IdOrder, e.IdOrderStatusFk, e.IdPaymentDetailsFk, e.IdShipmentAdressFk, e.IdUserFk, e.IdShipmentDetailsFk })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0, 0, 0 });

                entity.ToTable("order");

                entity.HasIndex(e => e.IdOrderStatusFk, "fk_order_order_status1_idx");

                entity.HasIndex(e => e.IdPaymentDetailsFk, "fk_order_payment_details1_idx");

                entity.HasIndex(e => e.IdShipmentAdressFk, "fk_order_shipment_adress1_idx");

                entity.HasIndex(e => e.IdShipmentDetailsFk, "fk_order_shipment_details1_idx");

                entity.HasIndex(e => e.IdUserFk, "fk_order_user1_idx");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.IdOrderStatusFk).HasColumnName("id_order_status_fk");

                entity.Property(e => e.IdPaymentDetailsFk).HasColumnName("id_payment_details_fk");

                entity.Property(e => e.IdShipmentAdressFk).HasColumnName("id_shipment_adress_fk");

                entity.Property(e => e.IdUserFk).HasColumnName("id_user_fk");

                entity.Property(e => e.IdShipmentDetailsFk).HasColumnName("id_shipment_details_fk");

                entity.Property(e => e.Canceled).HasColumnName("canceled");

                entity.Property(e => e.CanceledComment)
                    .HasMaxLength(256)
                    .HasColumnName("canceled_comment");

                entity.Property(e => e.CanceledDate)
                    .HasColumnType("datetime")
                    .HasColumnName("canceled_date");

                entity.Property(e => e.Comment)
                    .HasMaxLength(256)
                    .HasColumnName("comment");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("order_date");

                entity.Property(e => e.ShippingCost).HasColumnName("shipping_cost");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("token");

                entity.Property(e => e.TotalPrice).HasColumnName("total_price");

                entity.HasOne(d => d.IdOrderStatusFkNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdOrderStatusFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order_order_status");

                entity.HasOne(d => d.IdPaymentDetailsFkNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdPaymentDetailsFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order_payment_details");

                entity.HasOne(d => d.IdShipmentAdressFkNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdShipmentAdressFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order_shipment_adress");

                entity.HasOne(d => d.IdShipmentDetailsFkNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdShipmentDetailsFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order_shipment_details");

                entity.HasOne(d => d.IdUserFkNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdUserFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order_user");
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.HasKey(e => new { e.IdOrderProduct, e.IdProductFk, e.IdOrderFk })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("order_product");

                entity.HasIndex(e => e.IdOrderFk, "fk_order_product_order1_idx");

                entity.HasIndex(e => e.IdProductFk, "fk_order_product_product1_idx");

                entity.Property(e => e.IdOrderProduct).HasColumnName("id_order_product");

                entity.Property(e => e.IdProductFk).HasColumnName("id_product_fk");

                entity.Property(e => e.IdOrderFk).HasColumnName("id_order_fk");

                entity.Property(e => e.PriceEach).HasColumnName("price_each");

                entity.Property(e => e.QuantityOrder).HasColumnName("quantity_order");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.HasKey(e => e.IdOrderStatus)
                    .HasName("PRIMARY");

                entity.ToTable("order_status");

                entity.Property(e => e.IdOrderStatus)
                    .ValueGeneratedNever()
                    .HasColumnName("id_order_status");

                entity.Property(e => e.NameStatus)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("name_status");
            });

            modelBuilder.Entity<PaymentDetail>(entity =>
            {
                entity.HasKey(e => e.IdPaymentDetails)
                    .HasName("PRIMARY");

                entity.ToTable("payment_details");

                entity.Property(e => e.IdPaymentDetails)
                    .ValueGeneratedNever()
                    .HasColumnName("id_payment_details");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.IdProvider)
                    .HasMaxLength(45)
                    .HasColumnName("id_provider");

                entity.Property(e => e.Provider)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("provider");

                entity.Property(e => e.StatusProvider)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("status_provider");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => new { e.IdProduct, e.IdCategoryFk })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("product");

                entity.HasIndex(e => e.IdCategoryFk, "fk_product_category_idx");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.IdCategoryFk).HasColumnName("id_category_fk");

                entity.Property(e => e.ContentText)
                    .HasMaxLength(256)
                    .HasColumnName("content_text");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.PublishedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("published_date");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(256)
                    .HasColumnName("short_description");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("title");

                entity.HasOne(d => d.IdCategoryFkNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdCategoryFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_product_category");
            });

            modelBuilder.Entity<ShipmentAdress>(entity =>
            {
                entity.HasKey(e => e.IdShipmentAdress)
                    .HasName("PRIMARY");

                entity.ToTable("shipment_adress");

                entity.HasIndex(e => e.IdUserFk, "fk_user_adress_user1_idx");

                entity.Property(e => e.IdShipmentAdress)
                    .ValueGeneratedNever()
                    .HasColumnName("id_shipment_adress");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("adress");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("city");

                entity.Property(e => e.CityCode)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("city_code");

                entity.Property(e => e.Company)
                    .HasMaxLength(256)
                    .HasColumnName("company");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("country");

                entity.Property(e => e.IdUserFk).HasColumnName("id_user_fk");

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("mobile");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("surname");

                entity.HasOne(d => d.IdUserFkNavigation)
                    .WithMany(p => p.ShipmentAdresses)
                    .HasForeignKey(d => d.IdUserFk)
                    .HasConstraintName("fk_user_adress_user");
            });

            modelBuilder.Entity<ShipmentDetail>(entity =>
            {
                entity.HasKey(e => e.IdShipmentDetails)
                    .HasName("PRIMARY");

                entity.ToTable("shipment_details");

                entity.Property(e => e.IdShipmentDetails)
                    .ValueGeneratedNever()
                    .HasColumnName("id_shipment_details");

                entity.Property(e => e.BarcodeProvider)
                    .HasMaxLength(256)
                    .HasColumnName("barcode_provider");

                entity.Property(e => e.ProviderName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("provider_name");

                entity.Property(e => e.ShipmentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("shipment_date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("status");

                entity.Property(e => e.StatusProvider)
                    .HasMaxLength(256)
                    .HasColumnName("status_provider");

                entity.Property(e => e.TrackingNumber)
                    .HasMaxLength(256)
                    .HasColumnName("tracking_number");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.HasKey(e => new { e.IdShoppingCart, e.IdProductFk, e.IdCartFk })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("shopping_cart");

                entity.HasIndex(e => e.IdCartFk, "fk_shopping_cart_cart1_idx");

                entity.HasIndex(e => e.IdProductFk, "fk_shopping_cart_product1_idx");

                entity.Property(e => e.IdShoppingCart).HasColumnName("id_shopping_cart");

                entity.Property(e => e.IdProductFk).HasColumnName("id_product_fk");

                entity.Property(e => e.IdCartFk).HasColumnName("id_cart_fk");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.PriceEach).HasColumnName("price_each");

                entity.Property(e => e.QuantityCart).HasColumnName("quantity_cart");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_date");

                entity.HasOne(d => d.IdCartFkNavigation)
                    .WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.IdCartFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_shopping_cart_cart");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PRIMARY");

                entity.ToTable("user");

                entity.Property(e => e.IdUser)
                    .ValueGeneratedNever()
                    .HasColumnName("id_user");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("email");

                entity.Property(e => e.EmailConfirmed).HasColumnName("email_confirmed");

                entity.Property(e => e.Lockout).HasColumnName("lockout");

                entity.Property(e => e.LockoutDate)
                    .HasColumnType("datetime")
                    .HasColumnName("lockout_date");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("password_hash");

                entity.Property(e => e.PhoneNumer)
                    .HasMaxLength(256)
                    .HasColumnName("phone_numer");

                entity.Property(e => e.PhoneNumerConfirmed).HasColumnName("phone_numer_confirmed");

                entity.Property(e => e.TwoFactoryEnabled).HasColumnName("two_factory_enabled");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("user_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
