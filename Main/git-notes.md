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

## Task 35
### Rebase result
Выполнена команда `git rebase -i HEAD~3`.
В редакторе три коммита были объединены (squash) в один.
Итоговый лог после rebase:

dd36cb3 (HEAD -> feature/rebase-demo, origin/feature/rebase-demo) feat: combined commits for rebase demo
e76b6cf (origin/level-2, level-2) chore: add gitignore and editorconfig
0ba4e5b feat: task 34 - linq word grouping
7cd1f60 feat: task 33 - linq employees queries
7731464 feat: task 32 - temperature with validation
