#!/bin/bash

sudo apt update
function install() {
	sudo apt install -y $*
}

# Installing basics
install zsh
install neovim ripgrep tig 
install clang cmake
install ninja-build

# Install boost
install libboost-filesystem-dev libboost-chrono-dev libboost-regex-dev libboost-program-options-dev libboost-date-time-dev\n

# Fancy prompt
git clone --depth=1 https://github.com/romkatv/powerlevel10k.git ${ZSH_CUSTOM:-$HOME/.oh-my-zsh/custom}/themes/powerlevel10k
sed -i 's/ZSH_THEME=".*"/ZSH_THEME="powerlevel10k\/powerlevel10k"/' ~/.zshrc
typeset -g POWERLEVEL9K_INSTANT_PROMPT=quiet
source ~/.zshrc
chsh -s $(which zsh)

echo >>>>> Setting up SSH Key <<<<<
ssh-keygen
cat ~/.ssh/id_rsa.pub
echo >>>>> Add this to GitHub SSH Key list <<<<<

