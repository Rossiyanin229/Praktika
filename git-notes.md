# Git notes

## Task 15 — Basic git

### Commands
- Инициализация репозитория (через интерфейс VS, аналог `git init`)
- Создание коммитов (аналог `git commit -m "..."`)
- Создание ветки `feature/git-basics` (аналог `git branch` + `git checkout`)
- Слияние ветки в `main` (аналог `git merge`)
- Разрешение конфликта (ручное удаление маркеров и `git add` + `git commit`)

### Output (git log --graph --oneline --all)
* merge: task 15 - resolve conflict
* fix: task 15 - change in main to cause conflict
* feat: task 15 - change in feature branch
* docs: task 15 - add second line
* feat: task 15 - initial commit

### What I learned
Я научился создавать локальный репозиторий, делать коммиты, создавать ветки и, самое главное, разрешать конфликты слияния вручную. Понял, что `git add` нужен перед коммитом, когда правишь конфликт.