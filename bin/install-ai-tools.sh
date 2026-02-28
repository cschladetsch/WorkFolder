#!/bin/zsh

echo "Installing Node.js..."
brew install node mas

echo "Installing Claude Code..."
npm install -g @anthropic-ai/claude-code

echo "Installing Gemini CLI..."
npm install -g @google/gemini-cli

echo "Installing Xcode (this will take a while)..."
mas install 497799835

echo "Done. Grok CLI not available yet - use API directly."
echo "After Xcode installs, run: brew install coursier/formulas/coursier && cs setup"
