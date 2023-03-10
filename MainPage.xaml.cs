using DataBaseApp.Data;

namespace DataBaseApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	

    public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		

		DatabaseItems databaseItems = await DatabaseItems.Instance;
		TableItems items = new TableItems();
		items.count = 4;
		await databaseItems.saveItemAsync(items);
		var cc = await databaseItems.GetTableItemsAsync();
		var size = cc.Count + 1;
        CounterBtn.Text = $"Count: {size}";
        SemanticScreenReader.Announce(CounterBtn.Text);
   
	}
}

