Тестовое задание для отклика на вакнсию. Применил MVC в  проекте. Данные выделены в в отдельные структуры с постфиксом Data. Модели хранят в себе логику работы с данными и данные. Контроллеры хранят в себе и модели и логику. Сделал Один общий Main Controller для этой цели. Окна UI представляют из себя вьюшки и они наследуются от window. Сделан Window Manager для удобной работы с окнами UI. Окна UI хранятся в виде префабов в Resources/Windows. Они автоматически подгружаются по требованию если еще не открыты. Подключил remote Config для передачи файла кофигурации в виде Json. Предметы определены в scriptable objects.  В начале игры они инициализируют  словари с ключами string. И во время открытия всплывающего окна с предложением подтягивают спрайты по string ключу.