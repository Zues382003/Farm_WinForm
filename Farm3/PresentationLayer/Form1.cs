using Farm.BusinessLayer;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Farm
{
	public partial class Form1 : Form
	{
		private Cow cow;
		private Sheep sheep;
		private Goat goat;
		public Form1()
		{
			InitializeComponent();
		}

		private void btnInit_Click(object sender, EventArgs e)
		{
			int cowCount = int.Parse(txtCowCount.Text);
			int sheepCount = int.Parse(txtSheepCount.Text);
			int goatCount = int.Parse(txtGoatCount.Text);

			cow = new Cow(cowCount);
			sheep = new Sheep(sheepCount);
			goat = new Goat(goatCount);

			using (var context = new FarmDbContext())
			{
				// Kiểm tra xem gia súc có tên "Bò" đã tồn tại chưa
				var existingCow = context.Animals.FirstOrDefault(a => a.Name == "Bò");
				if (existingCow != null)
				{
					// Nếu đã tồn tại, cập nhật số lượng
					existingCow.Quantity += cow.Quantity;
				}
				else
				{
					// Nếu chưa tồn tại, thêm mới
					context.Animals.Add(new DataLayer.Animal
					{
						Name = "Bò",
						Quantity = cow.Quantity
					});
				}

				// Kiểm tra xem gia súc có tên "Cừu" đã tồn tại chưa
				var existingSheep = context.Animals.FirstOrDefault(a => a.Name == "Cừu");
				if (existingSheep != null)
				{
					// Nếu đã tồn tại, cập nhật số lượng
					existingSheep.Quantity += sheep.Quantity;
				}
				else
				{
					// Nếu chưa tồn tại, thêm mới
					context.Animals.Add(new DataLayer.Animal
					{
						Name = "Cừu",
						Quantity = sheep.Quantity
					});
				}

				// Kiểm tra xem gia súc có tên "Dê" đã tồn tại chưa
				var existingGoat = context.Animals.FirstOrDefault(a => a.Name == "Dê");
				if (existingGoat != null)
				{
					// Nếu đã tồn tại, cập nhật số lượng
					existingGoat.Quantity += goat.Quantity;
				}
				else
				{
					// Nếu chưa tồn tại, thêm mới
					context.Animals.Add(new DataLayer.Animal
					{
						Name = "Dê",
						Quantity = goat.Quantity
					});
				}

				// Lưu thay đổi vào cơ sở dữ liệu
				context.SaveChanges();
			}

			MessageBox.Show("Gia súc đã được nhập vào.");
		}

		private void btnHearSounds_Click(object sender, EventArgs e)
		{
			string sounds = $"Bò: {cow.MakeSound()}\nCừu: {sheep.MakeSound()}\nDê: {goat.MakeSound()}";
			MessageBox.Show(sounds);
		}

		private void btnStatistics_Click(object sender, EventArgs e)
		{
			// Tính tổng gia súc sau khi sinh
			int newCows = cow.Quantity + cow.Quantity * cow.Reproduce();
			int newSheep = sheep.Quantity + sheep.Quantity * sheep.Reproduce();
			int newGoats = goat.Quantity + goat.Quantity * goat.Reproduce();

			// Tính tổng sữa
			int totalMilk = (cow.Quantity * cow.GiveMilk()) +
			(sheep.Quantity * sheep.GiveMilk()) +
							(goat.Quantity * goat.GiveMilk());

			string result = $"Số lượng gia súc sau sinh:\nBò: {newCows}\nCừu: {newSheep}\nDê: {newGoats}\n" +
							$"Tổng số lít sữa: {totalMilk} lít";

			MessageBox.Show(result);
		}
	}
}