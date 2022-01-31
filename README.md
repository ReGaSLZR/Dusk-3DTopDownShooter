# Dusk-3DTopDownShooter

Submitter: Renelie Salazar

LinkedIn: https://www.linkedin.com/in/renelie-salazar-80828a95/


# Plugins / Libraries / Packages Used:
- Cinemachine
- TextMeshPro
- Zenject (for dependency injection)
- UniRx (for Reactive programming)
- NaughtyAttributes (for Inspector fields)


# How to: Calibrate Gameplay Configuration
- Change the existing values in the Scriptable Objects inside the `Assets/Config` directory.


# How to: Use brand-new Configurations
[1] Create a new Config file. Right-click in the Project Window (ideally inside `Assets/Config` directory)

Follow menu: `Create > ReGaSLZR > Config > [Choose Config option]`

![alt text](https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/08a50655-d954-462d-a65a-4fb5d8df66ad/dez4oz6-1c3325a7-9399-4167-9d21-71d613f3e6d9.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzA4YTUwNjU1LWQ5NTQtNDYyZC1hNjVhLTRmYjVkOGRmNjZhZFwvZGV6NG96Ni0xYzMzMjVhNy05Mzk5LTQxNjctOWQyMS03MWQ2MTNmM2U2ZDkucG5nIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0._UYsOUgyD6fwSoaYwMzoxfFEJK6XlDh5aed2NFT02bg)

[2] Change the existing config with your newly-created config Scriptable Object

The Change should be done in `Gameplay Scene`'s "INJECTION" GameObject > `SceneContext` component > `Scriptable Object Installers` list

![alt text](https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/08a50655-d954-462d-a65a-4fb5d8df66ad/dez4ozb-0675e49b-10bc-4a4d-b695-d9d44ecaee31.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzA4YTUwNjU1LWQ5NTQtNDYyZC1hNjVhLTRmYjVkOGRmNjZhZFwvZGV6NG96Yi0wNjc1ZTQ5Yi0xMGJjLTRhNGQtYjY5NS1kOWQ0NGVjYWVlMzEucG5nIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.dNBigw2fLW42Ye_JIhZfSnSLE4_SlH29mnZd5FDSoCQ)


# How to: Create a new Enemy Type

[1] Create a `Variant` of any of the prefabs in `Assets/Prefabs/Enemy`

Right-click on selected existing prefab > `Create > Prefab Variant`

![alt text](https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/08a50655-d954-462d-a65a-4fb5d8df66ad/dez4ozd-7368d893-ded5-4824-bf65-7d4d761d658d.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzA4YTUwNjU1LWQ5NTQtNDYyZC1hNjVhLTRmYjVkOGRmNjZhZFwvZGV6NG96ZC03MzY4ZDg5My1kZWQ1LTQ4MjQtYmY2NS03ZDRkNzYxZDY1OGQucG5nIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.mrzC_esB0B6fpWVrsKWz4wzlzPhtg5b_aUgrSDn7bNs)

[2] Configure that new variant. Reskin it if you want. Change its model. Knock yourself out. :3

[3] On `Assets/Config`, there's a Scriptable Object called `EnemyTypes Config`. You can add a new entry to its list with your new Enemy prefab variant and an existing Enemy Config (from `Assets/Config/Enemies`). Or you create a brand-new Enemy Config with your fresh, new values as well. Just don't forget to assign your prefab variant and your Enemy config into the list in the `EnemyTypes Config`.

![alt text](https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/08a50655-d954-462d-a65a-4fb5d8df66ad/dez4sel-7ac274a8-7b7e-4d04-bd13-9da3acee035f.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzA4YTUwNjU1LWQ5NTQtNDYyZC1hNjVhLTRmYjVkOGRmNjZhZFwvZGV6NHNlbC03YWMyNzRhOC03YjdlLTRkMDQtYmQxMy05ZGEzYWNlZTAzNWYucG5nIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.Owd6qq9PGzQJZm5uVD4LlCR_gioMQYFLLhiuaOnOkvA)

NOTE: Of course, you can create your very own EnemyTypes config as well. Just follow the "How to: Use brand-new Configurations" section.
