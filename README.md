# GamesDB.WebApi

Web Api с использованием репозиториев для взаимодействия с базой данных, в которой хранятся данные о видеоиграх.

Слой Сущности (Domain):
Классы Game, Genre, Developer

Слой Сценарии (DAL):
Взаимодействие с базой данных.
Создание, получение, удаление, редактирование сущностей.
Результатом взаимодействия является объект класса BaseDbResponse

Слой Сервис (Service):
Наборы сервисов для дальнейшей передачи данных в контроллеры.
Бизнес-логика

Слой приложения:
Контроллеры и т. д.
